using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using MyWayRazor.Data;
using MyWayRazor.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace MyWayRazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MywayDbContext>();
                    DbInitializer.Initialize(context);

                    var userManager = services.GetRequiredService<UserManager<MyWayUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var icontext = services.GetRequiredService<IdentityContext>();
                    IdentityInitializer.SeedData(userManager, roleManager, icontext);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
