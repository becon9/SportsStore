using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SportsStore.Infrastructure.Interfaces;

namespace SportsStore.DAL.Context
{
    public class IdentityInitializer : IIdentityInitializer
    {
        private const string AdminUser = "Admin";
        private const string AdminPassword = "Secret123$";

        private readonly UserManager<IdentityUser> _userManager;

        public IdentityInitializer(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedData()
        {
            IdentityUser user = await _userManager.FindByIdAsync(AdminUser);
            if (user == null)
            {
                user = new IdentityUser(AdminUser);
                await _userManager.CreateAsync(user, AdminPassword);
            }
        }
    }
}
