using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Helpers
{
    public static class CreateUserHelper
    {
        public static async Task CreateUserAsync(WebApplication app)
        {
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                if (!userManager.Users.Any())
                {
                    await userManager.CreateAsync(new()
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@admin.com",
                        UserName = "Admin"
                    }, "1");
                }
            }
        }
    }
}
