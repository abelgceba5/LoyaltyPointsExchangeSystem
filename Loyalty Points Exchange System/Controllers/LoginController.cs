﻿using LoyaltyPointsExchangeSystem.Interface;
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
        private readonly ILogout _logoutProvider;


        public LoginController(ILogin loginProvider, ILogout logoutProvider)
        {
            _loginProvider = loginProvider;
            _logoutProvider = logoutProvider;
        }




        [HttpGet]
        [Route("AuthenticateUsername/{username}/{password}")]
        public IActionResult IsValidLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest(new { message = "Username and password are required." });
            }

            int userId = _loginProvider.GetUserId(username); // Retrieve user ID

            if (userId == -1 || !_loginProvider.IsValidLogin(new Login { Username = username, Password = password }))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            Console.WriteLine($"User ID: {userId}");

            return Ok(new { userId, message = "Login successful" }); // Return user ID along with the message
        }



        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _logoutProvider.LogoutAsync();
            return Ok("Logout successful");
        }
    }
}
