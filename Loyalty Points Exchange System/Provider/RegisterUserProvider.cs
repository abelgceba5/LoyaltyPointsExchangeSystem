
using LoyaltyPointsExchangeSystem.AppDbContext;
using LoyaltyPointsExchangeSystem.Interface;
using LoyaltyPointsExchangeSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyPointsExchangeSystem.Provider
{
    public class RegisterUserProvider:IRegisterUser
    {

        private readonly DBContext _dBContext;
        public RegisterUserProvider(DBContext dbContext)
        {


            _dBContext = dbContext;
        }

        public bool IsValidRegistration()
        {
          
            return true;
        }

        public void RegisterUser(RegisterUser user)
        {
            
            _dBContext.registerUsers.Add(user);
            _dBContext.SaveChanges();
        }

        public async Task<IEnumerable<RegisterUser>> GetAllUsersAsync()
        {
            return await _dBContext.registerUsers.ToListAsync();
        }

        public async Task<RegisterUser> GetRegisteredUserByIdAsync(int userId)
        {
            return await _dBContext.registerUsers.FirstOrDefaultAsync(u => u.RegisterUserId == userId);
        }

    }
}
