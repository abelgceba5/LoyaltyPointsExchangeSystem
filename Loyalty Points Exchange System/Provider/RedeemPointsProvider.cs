using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.AppDbContext;
using LoyaltyPointsExchangeSystem.Interface;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyPointsExchangeSystem.Provider
{
    public class RedeemPointsProvider: IRedeemPoints
    {
        private readonly DBContext _dbContext;

        public RedeemPointsProvider(DBContext dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task<bool> RedeemPointsAsync(int userId, int pointsRedeemed, decimal amountRedeemed)
        {
            try
            {
                // Check if the user exists
                var user = await _dbContext.registerUsers.FirstOrDefaultAsync(u => u.RegisterUserId == userId);
                if (user == null)
                {
                    // User not found
                    return false;
                }

                // Create a redemption record
                var redemptionRecord = new RedeemPoints
                {
                    RegisterUserId = userId,
                    PointsRedeemed = pointsRedeemed,
                    AmountRedeemed = amountRedeemed,
                    RedeemedDate = DateTime.Now
                };

                // Add redemption record to the database
                _dbContext.redeemPoints.Add(redemptionRecord);
                await _dbContext.SaveChangesAsync();

                return true; // Redemption successful
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Failed to redeem points: {ex.Message}");
                return false;
            }
        }
    }
}
