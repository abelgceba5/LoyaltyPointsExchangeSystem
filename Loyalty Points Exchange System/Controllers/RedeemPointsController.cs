using LoyaltyPointsExchangeSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Loyalty_Points_Exchange_System.Controllers.ItemController;

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
        //public async Task<IActionResult> RedeemPoints([FromBody] RedeemPointsRequest request)
        //{
        //    try
        //    {
        //        bool result = await _redeemPoints.RedeemPointsAsync(request.UserId, request.PointsRedeemed, request.AmountRedeemed);

        //        if (result)
        //        {
        //            return Ok("Points redeemed successfully.");
        //        }
        //        else
        //        {
        //            return BadRequest("Failed to redeem points.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle the exception
        //        Console.WriteLine($"Exception occurred during points redemption: {ex.Message}");
        //        return StatusCode(500, "An error occurred during points redemption.");
        //    }

        //}

        //[HttpPost("redeem")]
        //public async Task<ActionResult> RedeemPoints([FromBody] RedemptionRequest request)
        //{
        //    try
        //    {
        //        if (request == null)
        //        {
        //            return BadRequest("Invalid request body");
        //        }

        //        int userId = request.UserId;
        //        int pointsToRedeem = request.PointsToRedeem;
        //        decimal amountRedeemed = request.AmountRedeemed;

        //        bool redemptionSuccessful = await _redeemPoints.RedeemPointsAsync(userId, pointsToRedeem, amountRedeemed);
        //        if (redemptionSuccessful)
        //        {
        //            return Ok("Points redeemed successfully");
        //        }
        //        else
        //        {
        //            return BadRequest("Failed to redeem points. Insufficient points or invalid redemption amount.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        //    }
        //}
        [HttpPost]
        [Route("RedeemPoints/{userId}/{pointsToRedeem}/{amountRedeem}")]
        public async Task<ActionResult> RedeemPoints(int userId, int pointsToRedeem, decimal amountRedeemed)
        {
            try
            {
                bool redemptionSuccessful = await _redeemPoints.RedeemPointsAsync(userId, pointsToRedeem, amountRedeemed);
                if (redemptionSuccessful)
                {
                    return Ok(new { Success = true, Message = "Points redeemed successfully" });
                }
                else
                {
                    return BadRequest(new { Success = false, Error = "Failed to redeem points. Insufficient points or invalid redemption amount." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, new { Success = false, Error = "Internal server error" });
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
