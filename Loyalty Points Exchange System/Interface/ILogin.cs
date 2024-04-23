using LoyaltyPointsExchangeSystem.Models;

namespace LoyaltyPointsExchangeSystem.Interface
{
    public interface ILogin
    {
        bool IsValidLogin(Login user);
        int GetUserId(string username);
    }
}




