using DataLayer.Entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDatabaseInit
    {
        Task SeedAsync();
    }


    public  class DatabaseInit: IDatabaseInit

    {

        private readonly EFDBContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DatabaseInit(EFDBContext context, UserManager<ApplicationUsers> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);
            if(!await _context.Users.AnyAsync())
            {
                const string managerRoleName = "manager";
                const string userRoleName = "user";

               


                await _roleManager.CreateAsync(new ApplicationRole() { Name = managerRoleName });
                await _roleManager.CreateAsync(new ApplicationRole() { Name = userRoleName });
                ApplicationUsers manager = new ApplicationUsers() { UserName = "manager", FullName = "manager" }  ;
                ApplicationUsers user = new ApplicationUsers() {  UserName = "user", FullName = "user" };
                Customer customer = new Customer()
                {
                    Name = userRoleName,
                    Code = "0101010",
                    Address = "home",
                    User = user
                };
              
                await _userManager.CreateAsync(manager, "123123");
                await _userManager.CreateAsync(user, "123123");
                
                var managerInData = await _userManager.FindByNameAsync(manager.UserName);
                var userInData = await _userManager.FindByNameAsync(user.UserName);
                try
                {
                    await _userManager.AddToRoleAsync(managerInData,managerRoleName);
                    await _userManager.AddToRoleAsync(userInData,userRoleName);
                    await _context.AddAsync(customer);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }

                

            }

        }
    }

    
}
