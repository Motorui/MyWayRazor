using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyWayRazor.Data;


namespace MyWayRazor.Areas.Identity.Data
{
    public static class IdentityInitializer
    {
        public static void SeedData(UserManager<MyWayUser> userManager, RoleManager<IdentityRole> roleManager, IdentityContext context)
        {
            
            SeedRoles(roleManager);
            SeedUsers(userManager);

        }

        public static void SeedUsers (UserManager<MyWayUser> userManager)
        {

            if (userManager.FindByNameAsync("rui.santos@portway.pt").Result == null)
            {
                MyWayUser user = new MyWayUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "rui.santos@portway.pt",
                    Email = "rui.santos@portway.pt",
                    Name = "Rui Pereira"
                };

                IdentityResult result = userManager.CreateAsync(user, "rui050476").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                    "Administrador").Wait();
                }
            }


            if (userManager.FindByNameAsync("jpgerardo.ptw@Portway.pt").Result == null)
            {
                MyWayUser user = new MyWayUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "jpgerardo.ptw@Portway.pt",
                    Email = "jpgerardo.ptw@Portway.pt",
                    Name = "João P. Gerardo"
                };

                IdentityResult result = userManager.CreateAsync(user, "rui050476").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                    "Supervisor").Wait();
                }
            }
        }

        public static void SeedRoles (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Utilizador").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Utilizador"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Supervisor").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Supervisor"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Administrador").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

    }
}
