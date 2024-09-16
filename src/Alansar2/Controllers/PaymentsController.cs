using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PaymentsController(IConfiguration configuration, HttpClient httpClient, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _webHostEnvironment = webHostEnvironment;
        }

        // Endpoint to generate Flutterwave payment link
        //[HttpPost("generate-payment-link")]
        //public async Task<IActionResult> GeneratePaymentLink([FromBody] PaymentRequest request)
        //{
        //    var flutterwaveSecretKey = _configuration["Flutterwave:SecretKey"];

        //    var requestData = new
        //    {
        //        tx_ref = $"TX_{Guid.NewGuid()}",
        //        amount = request.Amount,
        //        currency = "NGN",
        //        payment_type = "card",
        //        redirect_url = "http://localhost:5001/payment-confirmation", // Update this URL in production
        //        customer = new
        //        {
        //            email = request.Email,
        //            name = request.Name
        //        },
        //        customizations = new
        //        {
        //            title = "Room Booking",
        //            description = $"Payment for Room {request.RoomNumber}"
        //        }
        //    };

        //    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {flutterwaveSecretKey}");
        //    var response = await _httpClient.PostAsJsonAsync("https://api.flutterwave.com/v3/payments", requestData);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseData = await response.Content.ReadFromJsonAsync<FlutterwaveResponse>();
        //        return Ok(responseData.data.link); // Return the payment link
        //    }

        //    return BadRequest("Failed to generate payment link.");
        //}
        //public record struct RequestData(string tx_ref, int amount, string currency, string payment_type
        //    ,string redirect_url, Customer customer, Customizations customizations);

        //public record Customer(string email, string name);
        //public record Customizations(string title, string description);

        [HttpPost("generate-payment-link")]
        public async Task<IActionResult> GeneratePaymentLink([FromBody] PaymentRequest request)
        {
            var flutterwaveSecretKey = _configuration["Flutterwave:SecretKey"];

            
            var requestData = new
            {
                tx_ref = $"TX_{Guid.NewGuid()}",
                amount = request.Amount,
                currency = "NGN",
                payment_type = "card",
                redirect_url = $"{_configuration["Authority"]}/payment-confirmation",
                //redirect_url = "http://localhost:5001/payment-confirmation",
                //redirect_url = "https://162.0.222.79:4090/payment-confirmation",
                customer = new
                {
                    email = request.Email,
                    name = request.Name
                },
                customizations = new
                {
                    title = "Room Booking",
                    description = $"Payment for Room {request.RoomNumber}"
                }
            };


            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", flutterwaveSecretKey);

            var response = await _httpClient.PostAsJsonAsync("https://api.flutterwave.com/v3/payments", requestData);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<FlutterwaveResponse>();
                return Ok(responseData.data.link); // Return the payment link
            }

            return BadRequest("Failed to generate payment link.");
        }

        // Endpoint to confirm payment status
        [HttpPost("confirm")]
        public IActionResult ConfirmPayment([FromBody] PaymentConfirmationRequest request)
        {
            // Here you could implement logic to handle the payment confirmation
            // such as updating the user's booking status, sending a receipt, etc.
            if (request.Status == "successful")
            {
                // Handle successful payment
                return Ok();
            }

            // Handle failed payment
            return BadRequest("Payment was not successful.");
        }
    }

    public class PaymentRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string RoomNumber { get; set; }
        public int Amount { get; set; } = 2000;
    }

    public class PaymentConfirmationRequest
    {
        public string Status { get; set; }
    }

    public class FlutterwaveResponse
    {
        public FlutterwaveData data { get; set; }
    }

    public class FlutterwaveData
    {
        public string link { get; set; }
    }
}
