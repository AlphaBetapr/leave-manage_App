using leave_manage_App.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_manage_App
{
    public static class SeedData
    {

        public static void Seed(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {

            SeedRoles(roleManager);
            SeedUsers(userManager);

        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            if(!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole { Name = "Administrator" };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole { Name = "Employee" };
                var result = roleManager.CreateAsync(role).Result;
            }

        }


        private static void SeedUsers(UserManager<Employee> userManager)
        {

            var users = userManager.GetUsersInRoleAsync("Employee").Result;

            if(userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {

                var user = new Employee
                { 
                    UserName = "admin@localhost.com", 
                    Email = "admin@localhost.com" 
                };
                var result = userManager.CreateAsync(user, "Pakistan@1").Result;

                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }

            }

        }

    }
}
