using Diplom.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Diplom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            var scope = host.Services.CreateScope();

            var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userMngr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleMngr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            ctx.Database.EnsureCreated();

            var adminRole = new IdentityRole("Admin");
            if (!ctx.Roles.Any())
            {
                roleMngr.CreateAsync(adminRole).GetAwaiter().GetResult();
            }

            if (!ctx.Users.Any(u => u.UserName == "administrator"))
            {
                var adminUser = new IdentityUser
                {
                    UserName = "administrator",
                    Email = "4NUOfficial@gmail.com"
                };
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
