
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using LoyaltyPointsExchangeSystem.Interface;

namespace LoyaltyPointsExchangeSystem.Provider
{

    public class LogoutProvider: ILogout
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutProvider(IHttpContextAccessor httpContextAccessor)
        {

            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogoutAsync()
        {
            // Sign out the user
            //await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //// Optionally, you may clear any session data or perform additional cleanup
            //_httpContextAccessor.HttpContext.Session.Clear();
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }


}
