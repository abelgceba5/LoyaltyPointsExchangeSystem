using LoyaltyPointsExchangeSystem.Interface;
using LoyaltyPointsExchangeSystem.AppDbContext;
using Loyalty_Points_Exchange_System.Models;
using Microsoft.EntityFrameworkCore;
using Loyalty_Points_Exchange_System.Interface;

namespace LoyaltyPointsExchangeSystem.Provider
{
    public class PointsTransferToUserProvider: IPointsTransferToUser
    {

        private readonly DBContext _dBContext;
        private readonly ITransactionHistory _transactionHistory;

        public PointsTransferToUserProvider(DBContext dBContext, ITransactionHistory transactionHistory)
        {
            _dBContext = dBContext;
            _transactionHistory = transactionHistory;
        }



        public async Task<bool> TransferPointsToUserAsync(int fromUserId, int toUserId, int pointsToTransfer)
        {
            try
            {
                // Retrieve the sender's and receiver's user accounts from the database
                var fromUser = await _dBContext.registerUsers
                    .Include(u => u.EarnedPoints)
                    .FirstOrDefaultAsync(u => u.RegisterUserId == fromUserId);

                var toUser = await _dBContext.registerUsers
                    .Include(u => u.EarnedPoints)
                    .FirstOrDefaultAsync(u => u.RegisterUserId == toUserId);

                if (fromUser == null || toUser == null)
                {
                    // User not found
                    return false;
                }

                // Calculate the total points earned by the sender
                int totalPointsEarned = fromUser.EarnedPoints.Sum(ep => ep.PointsEarned);

                // Ensure sender has enough points to transfer
                if (totalPointsEarned < pointsToTransfer)
                {
                    return false; // Insufficient points
                }

                int originalPointsToTransfer = pointsToTransfer;

                // Deduct transferred points from the sender's account
                foreach (var earnedPoint in fromUser.EarnedPoints.OrderBy(ep => ep.EarnedDate))
                {
                    if (pointsToTransfer <= 0)
                        break;

                    int pointsToDeduct = Math.Min(pointsToTransfer, earnedPoint.PointsEarned);
                    earnedPoint.PointsEarned -= pointsToDeduct;
                    pointsToTransfer -= pointsToDeduct; // Update pointsToTransfer after deduction
                }

                // Update the receiver's points
                foreach (var earnedPoint in toUser.EarnedPoints.OrderBy(ep => ep.EarnedDate))
                {
                    earnedPoint.PointsEarned += pointsToTransfer;
                    break; // Assuming only one entry for points in the receiver's account
                }

                // Save changes to the database
              await _dBContext.SaveChangesAsync();

                await _transactionHistory.RecordTransactionAsync(fromUserId, TransactionType.TransferToUser, -originalPointsToTransfer, 0, DateTime.Now);
                await _transactionHistory.RecordTransactionAsync(toUserId, TransactionType.TransferToUser, originalPointsToTransfer, 0, DateTime.Now);

                // Create a transfer record
                var transferRecord = new TransferToUser
                {
                    FromUserId = fromUserId,
                    ToUserId = toUserId,
                    PointsTransferred = originalPointsToTransfer,
                    TransferDate = DateTime.Now
                };


                // Add transfer record to the database
                _dBContext.TransferToUsers.Add(transferRecord);
                await _dBContext.SaveChangesAsync();

                return true; // Transfer successful
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Failed to transfer points to user: {ex.Message}");
                return false;
            }
        }




    }
}
