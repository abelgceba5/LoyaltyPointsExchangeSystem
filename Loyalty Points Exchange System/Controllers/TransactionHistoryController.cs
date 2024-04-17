using Loyalty_Points_Exchange_System.Interface;
using Loyalty_Points_Exchange_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_Points_Exchange_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {

        private readonly ITransactionHistory _transactionHistory;
        public TransactionHistoryController(ITransactionHistory transactionHistory)
        {

            _transactionHistory = transactionHistory;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetTransactionHistory(int userId)
        {
            try
            {
                var transactions = await _transactionHistory.GetTransactionHistoryAsync(userId);
                if (transactions == null)
                {
                    return NotFound("No transaction history found.");
                }

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while retrieving transaction history: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving transaction history.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactionHistory()
        {
            try
            {
                IEnumerable<TransactionHistory> history = await _transactionHistory.GetTransactionHistoryAsync();
                return Ok(history);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Exception occurred while retrieving transaction history: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving transaction history.");
            }
        }
    }
}
