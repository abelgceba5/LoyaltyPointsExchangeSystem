using Loyalty_Points_Exchange_System.Interface;
using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.AppDbContext;
using LoyaltyPointsExchangeSystem.Interface;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyPointsExchangeSystem.Provider
{
    public class RedeemPointsProvider: IRedeemPoints
    {
        private readonly DBContext _dbContext;
        private readonly ITransactionHistory _transactionHistory;

        public RedeemPointsProvider(DBContext dbContext, ITransactionHistory transactionHistory)
        {

            _dbContext = dbContext;
            _transactionHistory = transactionHistory;
        }

        //public async Task<bool> RedeemPointsAsync(int userId, int pointsRedeemed, decimal amountRedeemed)
        //{
        //    try
        //    {
        //        // Check if the user exists
        //        var user = await _dbContext.registerUsers.FirstOrDefaultAsync(u => u.RegisterUserId == userId);
        //        if (user == null)
        //        {
        //            // User not found
        //            return false;
        //        }

        //        // Create a redemption record
        //        var redemptionRecord = new RedeemPoints
        //        {
        //            RegisterUserId = userId,
        //            PointsRedeemed = pointsRedeemed,
        //            AmountRedeemed = amountRedeemed,
        //            RedeemedDate = DateTime.Now
        //        };

        //        // Add redemption record to the database
        //        _dbContext.redeemPoints.Add(redemptionRecord);
        //        await _dbContext.SaveChangesAsync();

        //        return true; // Redemption successful
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle the exception
        //        Console.WriteLine($"Failed to redeem points: {ex.Message}");
        //        return false;
        //    }
        //}

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

                // Calculate the total points earned by the user
                int totalPointsEarned = await GetUserTotalPointsAsync(userId);

                // Check if the user has enough points to redeem
                if (totalPointsEarned < pointsRedeemed)
                {
                    // Not enough points to redeem
                    return false;
                }

                // Calculate the amount to be redeemed based on the redemption logic
                // decimal amountRedeemed = CalculateRedemptionAmount(pointsRedeemed);
                decimal redemptionAmount = CalculateRedemptionAmount(pointsRedeemed);

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
                await _transactionHistory.RecordTransactionAsync(userId, TransactionType.RedeemPoints, pointsRedeemed, amountRedeemed, DateTime.Now);
                return true; // Redemption successful
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Failed to redeem points: {ex.Message}");
                return false;
            }
        }

        private async Task<int> GetUserTotalPointsAsync(int userId)
        {
            // Calculate total points earned by the user
            return await _dbContext.earnPoints
                .Where(ep => ep.RegisterUserId == userId)
                .SumAsync(ep => ep.PointsEarned);
        }

        private decimal CalculateRedemptionAmount(int pointsEarned)
        {
            // Redemption logic: 1 point = 0.1 rand
            return pointsEarned / 10m; // Use decimal division to ensure accurate results
        }
    }
}
