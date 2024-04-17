

using LoyaltyPointsExchangeSystem.Interface;
using LoyaltyPointsExchangeSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_Points_Exchange_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {

        private readonly IRegisterUser _registerUserProvider;

        public RegisterUserController(IRegisterUser registerUserProvider)
        {
            _registerUserProvider = registerUserProvider;
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUser user)
        {
            if (!_registerUserProvider.IsValidRegistration())
            {
                return BadRequest("Invalid registration data");
            }

            // Optionally, you can perform additional validation here before saving the user
            // For example: if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                _registerUserProvider.RegisterUser(user);
                return Ok("User registered successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while registering user: {ex.Message}");
            }
        }
    }
}
