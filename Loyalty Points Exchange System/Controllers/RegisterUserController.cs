

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

            //test
        }

        //[HttpPost]
        //public IActionResult RegisterUser(RegisterUser user)
        //{
        //    if (!_registerUserProvider.IsValidRegistration())
        //    {
        //        return BadRequest("Invalid registration data");
        //    }

        //    // Optionally, you can perform additional validation here before saving the user
        //    // For example: if (!ModelState.IsValid) { return BadRequest(ModelState); }

        //    try
        //    {
        //        _registerUserProvider.RegisterUser(user);
        //        return Ok("User registered successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred while registering user: {ex.Message}");
        //    }
        //}
        //[HttpPost]
        //public IActionResult RegisterUser(RegisterUser user)
        //{
        //    if (!_registerUserProvider.IsValidRegistration())
        //    {
        //        return BadRequest(new { Success = false, Error = "Invalid registration data" });
        //    }



        //    try
        //    {
        //        _registerUserProvider.RegisterUser(user);
        //        return Ok(new { Success = true, Message = "User registered successfully" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { Success = false, Error = $"An error occurred while registering user: {ex.Message}" });
        //    }
        //}
        [HttpPost]
        [Route("AuthenticateUsername/{username}/{password}")]
        public IActionResult RegisterUser(string username, string password)
        {
            // Check if the provided username and password are valid
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest(new { Success = false, Error = "Username or password cannot be empty" });
            }

            // Add any additional validation logic here if needed

            try
            {
                // Call your register user provider method passing username and password
                _registerUserProvider.RegisterUser(username, password);


                return Ok(new { Success = true, Message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Error = $"An error occurred while registering user: {ex.Message}" });
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _registerUserProvider.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
