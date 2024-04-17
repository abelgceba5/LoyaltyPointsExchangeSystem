using Loyalty_Points_Exchange_System.Models;

namespace Loyalty_Points_Exchange_System.Interface
{
    public interface ITransactionHistory
    {

        Task<bool> RecordTransactionAsync(int userId, TransactionType type, int pointsChanged, decimal amountChanged, DateTime transactionDate);
        Task<IEnumerable<TransactionHistory>> GetTransactionHistoryAsync(int userId);
        Task<IEnumerable<TransactionHistory>> GetTransactionHistoryAsync();
    }
}
