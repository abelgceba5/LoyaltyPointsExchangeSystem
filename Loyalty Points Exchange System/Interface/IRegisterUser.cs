

using LoyaltyPointsExchangeSystem.Models;

namespace LoyaltyPointsExchangeSystem.Interface
{
    public interface IRegisterUser
    {

        bool IsValidRegistration();

        // void RegisterUser(RegisterUser user);
        void RegisterUser(string username, string password);

        Task<IEnumerable<RegisterUser>> GetAllUsersAsync();
    }
}
