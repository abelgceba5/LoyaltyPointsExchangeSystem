using Loyalty_Points_Exchange_System.Interface;
using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.AppDbContext;
using LoyaltyPointsExchangeystem.Interface;
using Microsoft.EntityFrameworkCore;
using NBitcoin.Secp256k1;

namespace LoyaltyPointsExchangeSystem.Provider
{
    public class ItemProvider : IItem
    {

        private readonly DBContext _dBContext;
        private readonly ITransactionHistory _transactionHistory;
        public ItemProvider(DBContext dbContext, ITransactionHistory transactionHistory)
        {

            _dBContext = dbContext;
            _transactionHistory = transactionHistory;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _dBContext.items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            return await _dBContext.items.FindAsync(itemId);
        }
        public async Task AddItemAsync(Item newItem)
        {
            _dBContext.items.Add(newItem);
            await _dBContext.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(int itemId, Item updatedItem)
        {
            var existingItem = await _dBContext.items.FindAsync(itemId);
            if (existingItem == null)
            {
                // Handle not found
                return;
            }

            existingItem.Name = updatedItem.Name;
            existingItem.Price = updatedItem.Price;

            await _dBContext.SaveChangesAsync();
        }

        public async Task<bool> PurchaseItemAsync(int itemId, int userId, decimal amount)
        {



            var item = await _dBContext.items.FindAsync(itemId);


            if (item == null)
            {
                return false;
            }


            if (!await UserIsEligibleToPurchaseAsync(userId, item.Price * amount))
            {
                return false;
            }


            if (item.Quantity < amount)
            {
                return true;
            }


            item.Quantity -= (int)amount;


            _dBContext.items.Update(item);
            await _dBContext.SaveChangesAsync();


            // Call method to earn points
            int pointsEarned = CalculatePointsEarned(amount); // Implement this method
            await EarnPointsAsync(userId, itemId, pointsEarned);

            // Record the transaction in the transaction history
            await _transactionHistory.RecordTransactionAsync(userId, TransactionType.PurchaseItem, pointsEarned, amount, DateTime.Now);
            return true;
        }

        public async Task<bool> UserIsEligibleToPurchaseAsync(int userId, decimal itemPrice)
        {
            // Check if the user exists
            var user = await _dBContext.registerUsers.FindAsync(userId);
            if (user == null)
            {
                return false; // User does not exist
            }


            return true;
        }


        private int CalculatePointsEarned(decimal amount)
        {

            // For example, you can award 1 point for every R10 spent
            return (int)(amount / 10);
        }


    
        public async Task EarnPointsAsync(int userId, int itemId, int pointsEarned)
        {
            var user = await _dBContext.registerUsers.FindAsync(userId);
            var item = await _dBContext.items.FindAsync(itemId);

            if (user != null && item != null)
            {
                // Calculate total points earned by the user
                int totalPointsEarned = await _dBContext.earnPoints
                    .Where(ep => ep.RegisterUserId == userId)
                    .SumAsync(ep => ep.PointsEarned);

                // Update TotalPointsEarned field
                totalPointsEarned += pointsEarned;

                var earnPoints = new EarnPoints
                {
                    RegisterUserId = userId,
                    ItemId = itemId,
                    PointsEarned = pointsEarned,
                    EarnedDate = DateTime.Now,
                    TotalPointsEarned = totalPointsEarned // Update the TotalPointsEarned field
                };

                _dBContext.earnPoints.Add(earnPoints);
                await _dBContext.SaveChangesAsync();


            }
        }
    }
}
