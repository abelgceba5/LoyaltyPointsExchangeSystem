using Loyalty_Points_Exchange_System.Interface;
using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace Loyalty_Points_Exchange_System.Provider
{
    public class TransactionHistoryProvider: ITransactionHistory
    {


        private readonly DBContext _dbContext;


        public TransactionHistoryProvider(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RecordTransactionAsync(int userId, TransactionType type, int pointsChanged, decimal amountChanged, DateTime transactionDate)
        {
            try
            {
 

               
                var transaction = new TransactionHistory
                {
                    RegisterUserId = userId,
                    Type = type,
                    PointsChanged = pointsChanged,
                    AmountChanged = amountChanged,
                    TransactionDate = transactionDate
                };

                _dbContext.transactionHistories.Add(transaction);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Failed to add transaction history: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<TransactionHistory>> GetTransactionHistoryAsync(int userId)
        {
            try
            {
                var transactions = await _dbContext.transactionHistories
                    .Where(t => t.RegisterUserId == userId)
                    .OrderByDescending(t => t.TransactionDate)
                    .ToListAsync();

                return transactions;
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Failed to retrieve transaction history: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<TransactionHistory>> GetTransactionHistoryAsync()
        {
            return await _dbContext.transactionHistories.ToListAsync();
        }
    }
}
