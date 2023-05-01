using Clean.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Clean.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@localhost").Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = "user@localhost";
                user.Email = "user@localhost";
                user.NormalizedUserName = "user@LOCALHOST";
                user.NormalizedEmail = "user@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
                var result = _userManager.CreateAsync(user, "usrNaXsp@9685").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("fauly@localhost").Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = "fauly@localhost";
                user.Email = "fauly@localhost";
                user.NormalizedUserName = "fauly@localhost";
                user.NormalizedEmail = "fauly@localhost";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
                var result = _userManager.CreateAsync(user, "admNaXsp@9685").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                _roleManager.CreateAsync(role).Wait();
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                _roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
