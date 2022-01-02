using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicineStore.Database
{
    public static class Initializer
    {
        public static async Task Initial(RoleManager<IdentityRole> rolemanager)
        {
            if(!await rolemanager.RoleExistsAsync("Admin"))
            {
                var users = new IdentityRole("Admin");
                await rolemanager.CreateAsync(users);
            }
            if (!await rolemanager.RoleExistsAsync("User"))
            {
                var users = new IdentityRole("User");
                 await rolemanager.CreateAsync(users);
            }



           /* if (!await rolemanager.RoleExistsAsync("manager"))
            { 
                var users = new IdentityRole("manager");
                await rolemanager.CreateAsync(users);
            }  */
        }
    } 
}
