using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MMM.Tests.Identity.Api.Database
{
    public static class ApplicationDbInitializer
    {
        public static void SeedAdminUser(UserManager<IdentityUser> userManager, IServiceProvider serviceProvider)
        {
            if (userManager.FindByEmailAsync("adm@adm.com").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "adm@adm.com",
                    Email = "adm@adm.com",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "Adm@12345").Result;

                if (result.Succeeded)
                {
                    AddRole(serviceProvider, "ADM");
                    userManager.AddToRoleAsync(user, "ADM").Wait();
                    userManager.AddClaimsAsync(user, GenerateJurosClaimsList()).Wait();
                }
            }
        }

        private static void AddRole(IServiceProvider serviceProvider, string roleName)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            IdentityResult roleResult;

            var roleCheck = RoleManager.RoleExistsAsync(roleName).Result;

            if (!roleCheck)
                roleResult = RoleManager.CreateAsync(new IdentityRole(roleName)).Result;
        }

        private static IEnumerable<Claim> GenerateJurosClaimsList()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("Juros", "Ler"));

            return claims;
        }
    }
}
