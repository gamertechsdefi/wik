using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WikiCatUSSDCode.Dtos;
using WikiCatUSSDCode.Services;

namespace WikiCatUSSDCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfricasTalkingController : ControllerBase
    {
        private readonly IAuthenticationServices _authServices;
        public AfricasTalkingController(IAuthenticationServices authenticationServices) 
        {
            _authServices = authenticationServices;
        }
        [HttpPost("USSDCallback")]
        public async Task<IActionResult> USSDCallback([FromForm] USSDRequestDto request)
        {
            string response = "Welcome to WikiCat USSD platform";

            string wikiCatBalance = "57,757,037.36 WKC";
            if(String.IsNullOrEmpty(request.Text))
            {
                response = "Welcome to WikiCat USSD platform \n";
                response += "1. Generate your wallet address \n";
                response += "2. Import your existing wallet backup phrase";
            }
            else if(request.Text == "1")
            {
                response = "Wait while address is being generated";
                response = "Address generated successfully";
                response = "1. Go to dashboard";
                response = "2. Cancel";
            }else if(request.Text == "1*1") {
                response = "Welcome to your dashboard";
                response += "1. Send $WKC \n";
                response += "2. Receive $WKC \n";
                response += "3. Check balance";
            }else if (request.Text == "1*1*1")
            {
                response = "Function not yet handled";
            }
            
            else if (request.Text == "1*1*2") {
                response = "Function not yet handled ";
            }
            else if (request.Text == "1*1*3") {
                response = "Your balance is" + wikiCatBalance;
            }
            else if(request.Text == "2") {
                response = "Enter your wallet backup phrase \n";
                response += "Wallet imported successfully \n";
                response += "1. Go to dashboard";
            }
            else if (request.Text == "2*1") {
                response = "Welcome to your dashboard";
                response += "1. Send $WKC \n";
                response += "2. Receive $WKC \n";
                response += "3. Check balance";
            }
            else if (request.Text == "2*1*1")
            {
                response = "Function not yet handled";
            }

            else if (request.Text == "2*1*2")
            {
                response = "Function not yet handled ";
            }
            else if (request.Text == "2*1*3")
            {
                response = "Your balance is" + wikiCatBalance;
            }
            else
            {
                response = "Connection insecure";
            }

            return Ok(response);

        }

    }
}
