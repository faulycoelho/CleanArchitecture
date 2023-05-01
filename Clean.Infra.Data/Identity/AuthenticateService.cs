using Clean.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManage;
        public AuthenticateService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManage)
        {
            _userManager = userManager;
            _signInManage = signInManage;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManage.PasswordSignInAsync(email, password, false, false);
            return result.Succeeded;
        }
        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                await _signInManage.SignInAsync(applicationUser, false);
            }

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManage.SignOutAsync();
        }

    }
}
