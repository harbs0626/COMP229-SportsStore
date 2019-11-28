using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "John";
        private const string adminPassword = "Secret123$";

        private const string managerUser = "Paul";
        private const string managerPassword = "Secret456$";

        private const string adminRoleName = "Admin";
        private const string managerRoleName = "Manager";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            // ** Initialize Role Manager and User Manager
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            // ** Create Admin role and user
            IdentityRole adminRole = await roleManager.FindByNameAsync(adminRoleName);
            if (adminRole == null)
            {
                adminRole = new IdentityRole(adminRoleName);
                await roleManager.CreateAsync(adminRole);
            }

            // ** Create the Admin user **
            IdentityUser adminUserIdentity = await userManager.FindByNameAsync(adminUser);
            if (adminUserIdentity == null)
            {
                adminUserIdentity = new IdentityUser(adminUser);
                await userManager.CreateAsync(adminUserIdentity, adminPassword);
                await userManager.AddToRoleAsync(adminUserIdentity, adminRoleName);
            }
            else
            {
                if (!(await userManager.IsInRoleAsync(adminUserIdentity, adminRoleName)))
                {
                    await userManager.AddToRoleAsync(adminUserIdentity, adminRoleName);
                }
            }

            userManager = null;
            userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            // ** Create Manager role and user
            IdentityRole managerRole = await roleManager.FindByNameAsync(managerRoleName);
            if (managerRole == null)
            {
                managerRole = new IdentityRole(managerRoleName);
                await roleManager.CreateAsync(managerRole);
            }

            // ** Create the Manager user **
            IdentityUser managerUserIdentity = await userManager.FindByNameAsync(managerUser);
            if (managerUserIdentity == null)
            {
                managerUserIdentity = new IdentityUser(managerUser);
                await userManager.CreateAsync(managerUserIdentity, managerPassword);
                await userManager.AddToRoleAsync(managerUserIdentity, managerRoleName);
            }
            else
            {
                if (!(await userManager.IsInRoleAsync(managerUserIdentity, managerRoleName)))
                {
                    await userManager.AddToRoleAsync(managerUserIdentity, managerRoleName);
                }
            }
        }
    }
}
