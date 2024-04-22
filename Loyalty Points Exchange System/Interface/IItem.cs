using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.Models;

namespace LoyaltyPointsExchangeystem.Interface
{
    public interface IItem
    {

        Task<IEnumerable<Item>> GetAllItemsAsync();

        Task<Item> GetItemByIdAsync(int itemId);

        Task AddItemAsync(Item newItem);

        Task UpdateItemAsync(int itemId, Item updatedItem);

        Task<bool> PurchaseItemAsync(int itemId, int userId, decimal amount);
        Task<bool> UserIsEligibleToPurchaseAsync(int userId, decimal itemPrice);

        Task EarnPointsAsync(int userId, int itemId, int pointsEarned);
        
    }
}
