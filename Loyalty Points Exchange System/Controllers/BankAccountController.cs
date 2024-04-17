using Loyalty_Points_Exchange_System.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyPointsExchangeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {

        private readonly IBankAccount _bankAccountProvider;

        public BankAccountController(IBankAccount bankAccountProvider)
        {

            _bankAccountProvider = bankAccountProvider;
        }



        [HttpPost("create")]
        public async Task<IActionResult> CreateBankAccountAsync(int userId, decimal initialBalance)
        {
            try
            {
                // Call the method to create a bank account
                var bankAccount = await _bankAccountProvider.CreateBankAccountAsync(userId, initialBalance);
                return Ok(bankAccount);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return a BadRequest response
                return BadRequest($"Failed to create bank account: {ex.Message}");
            }
        }
    }
}
