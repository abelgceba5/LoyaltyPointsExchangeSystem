using Loyalty_Points_Exchange_System.Interface;
using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.AppDbContext;
using LoyaltyPointsExchangeSystem.Interface;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyPointsExchangeSystem.Provider
{
    public class PointsTransferProvider : IPointsTransfer
    {

        private readonly DBContext _dBContext;
        private readonly ITransactionHistory _transactionHistory;
        public PointsTransferProvider(DBContext dbContext, ITransactionHistory transactionHistory)
        {

            _dBContext = dbContext;
            _transactionHistory = transactionHistory;
        }



        public async Task<bool> TransferPointsToBankAsync(int userId, int pointsToTransfer)
        {
            try
            {
                // Calculate the total points earned by the user
                int totalPointsEarned = await _dBContext.earnPoints
                    .Where(ep => ep.RegisterUserId == userId)
                    .SumAsync(ep => ep.PointsEarned);

                // Check if the user has enough accumulated points to transfer
                if (totalPointsEarned < pointsToTransfer)
                {
                    return false; // Insufficient points
                }

                // Retrieve the user's bank account from the database
                var bankAccount = await _dBContext.BankAccounts.FindAsync(userId);
                if (bankAccount == null)
                {
                    // Bank account not found for the user
                    return false;
                }

                // Perform the points transfer to the bank account
                bankAccount.Balance += pointsToTransfer;

                // Update the bank account balance in the database
                _dBContext.BankAccounts.Update(bankAccount);
                await _dBContext.SaveChangesAsync();

           

                       var pointsToRemove = _dBContext.earnPoints
                      .Where(ep => ep.RegisterUserId == userId)
                      .OrderBy(ep => ep.EarnedDate)
                      .ToList();

                // Record the transaction in the transaction history
                await _transactionHistory.RecordTransactionAsync(userId, TransactionType.TransferToBank, pointsToTransfer, 0, DateTime.Now);

                foreach (var point in pointsToRemove)
                {
                    if (pointsToTransfer >= point.PointsEarned)
                    {
                        // Remove the entire points record if points to transfer is greater or equal to the points earned
                        pointsToTransfer -= point.PointsEarned;
                        totalPointsEarned -= point.PointsEarned;
                        _dBContext.earnPoints.Remove(point);
                    }
                    else
                    {
                        // Reduce the points earned in the record
                        point.PointsEarned -= pointsToTransfer;
                        totalPointsEarned -= pointsToTransfer;
                        pointsToTransfer = 0;
                        break; // Exit the loop since pointsToTransfer becomes 0
                    }
                }

                // Update the bank account balance with transferred points
                bankAccount.Balance += pointsToTransfer;
                _dBContext.BankAccounts.Update(bankAccount);

                // Save changes to the database
                await _dBContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Failed to transfer points to bank account: {ex.Message}");
                return false;
            }
        }

        


    }
}

