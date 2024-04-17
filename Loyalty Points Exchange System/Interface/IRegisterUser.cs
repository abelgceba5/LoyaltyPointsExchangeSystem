

using LoyaltyPointsExchangeSystem.Models;

namespace LoyaltyPointsExchangeSystem.Interface
{
    public interface IRegisterUser
    {

        bool IsValidRegistration();

        void RegisterUser(RegisterUser user);
        Task<IEnumerable<RegisterUser>> GetAllUsersAsync();
    }
}
