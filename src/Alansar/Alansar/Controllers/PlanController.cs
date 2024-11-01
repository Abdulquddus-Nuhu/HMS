using Alansar.Core.Entities;
using Alansar.Core.Entities.Identity;
using Alansar.Core.Models.Requests.Plan;
using Alansar.Core.Models.Responses;
using Alansar.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PlanController> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public PlanController(AppDbContext context, ILogger<PlanController> logger,
            IConfiguration configuration, HttpClient httpClient)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_configuration["Flutterwave:Link"]);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["Flutterwave:SecretKey"]);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlan([FromBody] CreatePlanRequest request)
        {
            var response = new BaseResponse();

            var planExist = await _context.Plans.AnyAsync(x => x.Name == request.Name);
            if (planExist)
            {
                response.Status = false;
                response.Code = 400;
                response.Message = "Plan with the same name already exists!";
                return BadRequest(response);
            }

            PaymentPlanResponse? responseData = null;
            try
            {
                var apiResponse = await _httpClient.PostAsJsonAsync($"payment-plans", request);
                if (apiResponse.IsSuccessStatusCode)
                {
                    var contentStream = await apiResponse.Content.ReadAsStringAsync();
                    Console.WriteLine(contentStream);

                    responseData = await apiResponse.Content.ReadFromJsonAsync<PaymentPlanResponse>();
                }
                else if (apiResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    _logger.LogInformation("Received bad request status code from Flutterwave");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while calling Flutterwave. {Error}", ex.Message);
                return StatusCode(500, "Error occurred");
            }

            var plan = new Plan()
            {
                Id = Guid.NewGuid(),
                Name = responseData.Data.Name,
                Amount = responseData.Data.Amount,
                Status = responseData.Data.Status,
                Created = responseData.Data.CreatedAt,
                Currency = responseData.Data.Currency,
                Duration = responseData.Data.Duration,
                FlutterwavePlanId = responseData.Data.Id,
                Interval = responseData.Data.Interval,
                Token = responseData.Data.PlanToken
            };

            _context.Add(plan);
            await _context.SaveChangesAsync();

            response.Message = "Plan created successfully!";
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<Plan>>> GetAllPlans()
        {
            var plans = await _context.Plans.ToListAsync();
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlanById(Guid id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound(new BaseResponse { Status = false, Message = "Plan not found." });
            }
            return Ok(plan);
        }

        [HttpPut("")]
        public async Task<ActionResult> ActivateDeactivatePlan(Guid id, bool status)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound(new BaseResponse { Status = false, Message = "Plan not found." });
            }

            var request = new EditPlanRequest()
            {
                Name = plan.Name,
                Status = status == true ? "active" : "inactive",
            };

            // Update on Flutterwave API first
            try
            {
                var apiResponse = await _httpClient.PutAsJsonAsync($"payment-plans/{plan.FlutterwavePlanId}", request);
                if (!apiResponse.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Failed to update the plan on Flutterwave.");
                    return BadRequest(new BaseResponse { Status = false, Message = "Failed to update the plan on Flutterwave." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the plan on Flutterwave. {Error}", ex.Message);
                return StatusCode(500, "Error occurred while updating plan on Flutterwave.");
            }

            // Update locally
            plan.Name = request.Name;
            plan.Status = request.Status;

            _context.Update(plan);
            await _context.SaveChangesAsync();

            return Ok(new BaseResponse { Status = true, Message = "Plan updated successfully!" });
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> EditPlan(Guid id, [FromBody] EditPlanRequest request)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound(new BaseResponse { Status = false, Message = "Plan not found." });
            }

            request.Status = plan.Status;

            // Update on Flutterwave API first
            try
            {
                var apiResponse = await _httpClient.PutAsJsonAsync($"payment-plans/{plan.FlutterwavePlanId}", request);
                if (!apiResponse.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Failed to update the plan on Flutterwave.");
                    return BadRequest(new BaseResponse { Status = false, Message = "Failed to update the plan on Flutterwave." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the plan on Flutterwave. {Error}", ex.Message);
                return StatusCode(500, "Error occurred while updating plan on Flutterwave.");
            }

            // Update locally
            plan.Name = request.Name;
            plan.Status = request.Status;

            _context.Update(plan);
            await _context.SaveChangesAsync();

            return Ok(new BaseResponse { Status = true, Message = "Plan updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlan(Guid id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound(new BaseResponse { Status = false, Message = "Plan not found." });
            }

            // Call Flutterwave API to delete the plan first
            try
            {
                var apiResponse = await _httpClient.DeleteAsync($"payment-plans/{plan.FlutterwavePlanId}");
                if (!apiResponse.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Failed to delete the plan on Flutterwave.");
                    return BadRequest(new BaseResponse { Status = false, Message = "Failed to delete the plan on Flutterwave." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the plan on Flutterwave. {Error}", ex.Message);
                return StatusCode(500, "Error occurred while deleting plan on Flutterwave.");
            }

            // Delete locally
            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();

            return Ok(new BaseResponse { Status = true, Message = "Plan deleted successfully!" });
        }
    }
}
