using HR_System.Constants;
using HR_System.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Permissions = HR_System.Constants.Permissions;

namespace HR_System.Seeds
{
    public static class DefultUseres
    {
        public static async Task seedUser(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defultUser1 = new AppUser
            {
                fullName = "Mohamed Labn",
                Email = "Labn@ITI.com",
                UserName = "LabnITI"
            };
            var user1 = await userManager.FindByEmailAsync(defultUser1.Email);
            if(user1 == null)
            {
                await userManager.CreateAsync(defultUser1, "Labn@12345");
                await userManager.AddToRoleAsync(defultUser1, "Admin");
            }

            var defultUser2 = new AppUser
            {
                fullName = "Ahmed Magdy",
                Email = "Magdy@ITI.com",
                UserName = "MagdyITI"
            };
            var user2 = await userManager.FindByEmailAsync(defultUser2.Email);
            if (user2 == null)
            {
                await userManager.CreateAsync(defultUser2, "Magdy@12345");
                await userManager.AddToRoleAsync(defultUser2, "Admin");
            }

            var defultUser3 = new AppUser
            {
                fullName = "Hosny Salem",
                Email = "Hosny@ITI.com",
                UserName = "HosnyITI"
            };
            var user3 = await userManager.FindByEmailAsync(defultUser3.Email);
            if (user3 == null)
            {
                await userManager.CreateAsync(defultUser3, "Hosny@12345");
                await userManager.AddToRoleAsync(defultUser3, "Admin");
            }

            var defultUser4 = new AppUser
            {
                fullName = "Mohamed Mostafa",
                Email = "Mohamed@ITI.com",
                UserName = "MohamedITI"
            };
            var user4 = await userManager.FindByEmailAsync(defultUser4.Email);
            if (user4 == null)
            {
                await userManager.CreateAsync(defultUser4, "Mohamed@12345");
                await userManager.AddToRoleAsync(defultUser4, "Admin");
            }

            var defultUser5 = new AppUser
            {
                fullName = "Ahmed Tarek",
                Email = "Ahmed@ITI.com",
                UserName = "AhmedITI"
            };
            var user5 = await userManager.FindByEmailAsync(defultUser5.Email);
            if (user5 == null)
            {
                await userManager.CreateAsync(defultUser5, "Ahmed@12345");
                await userManager.AddToRoleAsync(defultUser5, "Admin");
            }

            var defultUser6 = new AppUser
            {
                fullName = "Mostafa Algohary",
                Email = "Mostafa@ITI.com",
                UserName = "MostafaITI"
            };
            var user6 = await userManager.FindByEmailAsync(defultUser6.Email);
            if (user6 == null)
            {
                await userManager.CreateAsync(defultUser6, "Mostafa@12345");
                await userManager.AddToRoleAsync(defultUser6, "Admin");
            }
            //TODO: seed Claims
            await roleManager.seedClaimsForAdmin();
        }
        public static async Task seedClaimsForAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            await roleManager.addPermissionsclaims(adminRole, "Users");
            await roleManager.addPermissionsclaims(adminRole, "Attendance");
            await roleManager.addPermissionsclaims(adminRole, "Employee");
            await roleManager.addPermissionsclaims(adminRole, "GeneralSettings");
            await roleManager.addPermissionsclaims(adminRole, "Holidays");
            await roleManager.addPermissionsclaims(adminRole, "Home");
            await roleManager.addPermissionsclaims(adminRole, "Roles");
            await roleManager.addPermissionsclaims(adminRole, "SalaryReport");
            await roleManager.addPermissionsclaims(adminRole, "Department");

        }
        public static async Task addPermissionsclaims(this RoleManager<IdentityRole> roleManager , IdentityRole role , string module) 
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.generatePermissionsList(module);
            foreach (var permission in allPermissions)
            {
                if(!allClaims.Any(c=>c.Type=="Permission" && c.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        } 

    }
}
