using LoyaltyPointsExchangeSystem.Interface;
using LoyaltyPointsExchangeSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_Points_Exchange_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginProvider;

        public LoginController(ILogin loginProvider)
        {
            _loginProvider = loginProvider;
           
        }

        [HttpPost]
        public IActionResult Login(Login user)
        {
            if (!_loginProvider.IsValidLogin(user))
            {
                return Unauthorized("Invalid username or password");
            }

            // Optionally, you can generate and return a JWT token here for authentication purposes

            return Ok("Login successful");
        }
    }
}
