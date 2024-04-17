using LoyaltyPointsExchangeSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_Points_Exchange_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferPointsToBank : ControllerBase
    {

        private readonly IPointsTransfer _pointsTransferProvider;

        public TransferPointsToBank(IPointsTransfer pointsTransferProvider)
        { 
            
           _pointsTransferProvider= pointsTransferProvider;
        }



        [HttpPost("transfer")]
        public async Task<IActionResult> TransferPoints(int userId, int pointsToTransfer)
        {
            try
            {
                // Call the method to transfer points to the bank account
                bool transferResult = await _pointsTransferProvider.TransferPointsToBankAsync(userId, pointsToTransfer);

                if (transferResult)
                {
                    return Ok("Points transferred successfully to the bank account.");
                }
                else
                {
                    return BadRequest("Failed to transfer points to the bank account. Insufficient points or user not found.");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Failed to transfer points to bank account: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

    }
}
