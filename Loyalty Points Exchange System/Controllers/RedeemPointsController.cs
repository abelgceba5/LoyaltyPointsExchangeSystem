using LoyaltyPointsExchangeSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_Points_Exchange_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedeemPointsController : ControllerBase
    {
        private readonly IRedeemPoints _redeemPoints;

        public RedeemPointsController(IRedeemPoints redeemPoints)
        {


            _redeemPoints = redeemPoints;
        }

        [HttpPost]
        public async Task<IActionResult> RedeemPoints([FromBody] RedeemPointsRequest request)
        {
            try
            {
                bool result = await _redeemPoints.RedeemPointsAsync(request.UserId, request.PointsRedeemed, request.AmountRedeemed);

                if (result)
                {
                    return Ok("Points redeemed successfully.");
                }
                else
                {
                    return BadRequest("Failed to redeem points.");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Exception occurred during points redemption: {ex.Message}");
                return StatusCode(500, "An error occurred during points redemption.");
            }

        }
        public class RedeemPointsRequest
        {
            public int UserId { get; set; }
            public int PointsRedeemed { get; set; }
            public decimal AmountRedeemed { get; set; }
        }
    }
}
