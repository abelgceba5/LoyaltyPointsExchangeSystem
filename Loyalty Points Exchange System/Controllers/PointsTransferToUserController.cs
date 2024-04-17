using LoyaltyPointsExchangeSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_Points_Exchange_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsTransferToUserController : ControllerBase
    {

        private readonly IPointsTransferToUser _pointsTransferToUser;

        public PointsTransferToUserController(IPointsTransferToUser pointsTransferToUser)
        {

            _pointsTransferToUser= pointsTransferToUser;
        }

        [HttpPost("transfer")]
        public async Task<ActionResult<bool>> TransferPointsToUser(int fromUserId, int toUserId, int pointsToTransfer)
        {
            try
            {
                bool transferResult = await _pointsTransferToUser.TransferPointsToUserAsync(fromUserId, toUserId, pointsToTransfer);

                if (transferResult)
                {
                    return Ok(true); 
                }
                else
                {
                    return BadRequest("Failed to transfer points to user.");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Failed to transfer points to user: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
