using Alansar.Core.Entities;
using Alansar.Core.Entities.Identity;
using Alansar.Core.Models.Requests;
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
                response.Message = "Plan with the same name already exist!";
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
                    _logger.LogInformation("Recieved bad request status code from flutterwave");
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("An Error occured while calling flutterwave. {Error}", ex.Message);
                return StatusCode(500,"Error occured");
            }


            var plan = new Plan()
            {
                Id = Guid.NewGuid(),
                Name = responseData.Data.Name,
                Amount = responseData.Data.Amount,
                status = responseData.Data.Status == "active" ? true : false,
                Created = responseData.Data.CreatedAt,
                Currency = responseData.Data.Currency,
                Duration = responseData.Data.Duration,
                FlutterwavePlanId = responseData.Data.Id,
                Interval = responseData.Data.Interval,
                Token = responseData.Data.PlanToken
            };

            _context.Add(plan);
            await _context.SaveChangesAsync();

            response.Message = "Plan Created successfully!";
            return Ok(response);
        }

    }
}
