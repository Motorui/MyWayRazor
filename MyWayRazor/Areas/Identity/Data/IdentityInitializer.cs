using System;
using Microsoft.AspNetCore.Identity;
using MyWayRazor.Areas.Identity.Models;
using MyWayRazor.Data;

namespace MyWayRazor.Areas.Identity.Data
{
    public static class IdentityInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
        }
            public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
        {
            
            SeedRoles(roleManager);
            SeedUsers(userManager);

        }

        public static void SeedUsers (UserManager<ApplicationUser> userManager)
        {

            if (userManager.FindByNameAsync("rui.santos@portway.pt").Result == null)
            {
                ApplicationUser user = new ApplicationUser
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
                ApplicationUser user = new ApplicationUser
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

            if (userManager.FindByNameAsync("alsmywaysup@ana.pt").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "alsmywaysup@ana.pt",
                    Email = "alsmywaysup@ana.pt",
                    Name = "Supervisão MyWay"
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                    "Supervisor").Wait();
                }
            }
        }

        public static void SeedRoles (RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Utilizador").Result)
            {
                ApplicationRole role = new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Utilizador"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Supervisor").Result)
            {
                ApplicationRole role = new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Supervisor"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Administrador").Result)
            {
                ApplicationRole role = new ApplicationRole
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
