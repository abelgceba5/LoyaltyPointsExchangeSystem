using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.Interface;
using LoyaltyPointsExchangeystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_Points_Exchange_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItem _item;
        private readonly IRegisterUser _registerUserProvider;
        public ItemController(IItem item, IRegisterUser registerUserProvider)
        {
            _item = item;

            _registerUserProvider = registerUserProvider;


        }

        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {

            try
            {
                await _item.AddItemAsync(item);
                return CreatedAtAction(null, new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
      
        //    // Retrieve item price
        //    var item = await _item.GetItemByIdAsync(itemId);
       


        //    bool purchaseResult = await _item.PurchaseItemAsync(itemId, userId, amount);

       

        [HttpPost("{itemId}/purchase")]
        public async Task<ActionResult> PurchaseItem(int itemId, int userId, decimal amount)
        {
            // Check if the user is eligible to purchase
            bool isEligible = await _item.UserIsEligibleToPurchaseAsync(userId, amount);

            if (!isEligible)
            {
                return BadRequest("User is not eligible to purchase the item.");
            }

            // Proceed with the purchase process
            bool purchaseResult = await _item.PurchaseItemAsync(itemId, userId, amount);

            // Calculate points earned based on the amount spent
            int pointsEarned = CalculatePointsEarned(amount);

            // Earn points for the purchase
            await _item.EarnPointsAsync(userId, itemId, pointsEarned);

            return Ok("Item purchased successfully. Points earned: " + pointsEarned);
        }

        private int CalculatePointsEarned(decimal amount)
        {
            
            return (int)(amount / 10);
        }
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _item.GetAllItemsAsync();
        }



    }
}
