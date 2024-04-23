using LoyaltyPointsExchangeSystem.AppDbContext;
using LoyaltyPointsExchangeSystem.Interface;
using LoyaltyPointsExchangeSystem.Models;

namespace Loyalty_Points_Exchange_System.Provider
{
    public class LoginProvider:ILogin
    {


        private readonly DBContext _dBContext;
        public LoginProvider(DBContext dbContext)
        {

            _dBContext = dbContext;
        }


        public bool IsValidLogin(Login user)
        {

            var existingUser = _dBContext.registerUsers.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            return existingUser != null;
        }
        public int GetUserId(string username)
        {
            var user = _dBContext.registerUsers.FirstOrDefault(u => u.Username == username);
            return user != null ? user.RegisterUserId : -1;
        }
    }
}
