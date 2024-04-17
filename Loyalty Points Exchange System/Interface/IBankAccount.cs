using LoyaltyPointsExchangeSystem.Models;

namespace Loyalty_Points_Exchange_System.Interface
{
    public interface IBankAccount
    {

        Task<BankAccount> CreateBankAccountAsync(int userId, decimal initialBalance);
    }
}
