using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Servieces.Implementation
{
    public class AccountManager : IAccountManager
    {

        private readonly EFDBContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountManager(EFDBContext context, UserManager<ApplicationUsers> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUsers user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<(bool Succeeded, string[] Errors)> CreateUserAsync(ApplicationUsers user, string roles, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            user = await _userManager.FindByNameAsync(user.UserName);
            try
            {
                result = await _userManager.AddToRoleAsync(user, roles);
            }
            catch
            {
                throw;
            }
            if (!result.Succeeded)
            {
                return (false, result.Errors.Select(e => e.Description).ToArray());
            }
            return (true, new string[] { });
            
        }

        public async Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(ApplicationUsers user)
        {
            var result =  await _userManager.DeleteAsync(user);
            
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());
           

            return (true, new string[] { });
        }

        public async Task<Customer> GetCustomerByUser(ApplicationUsers user)
        {
                 Customer customer = await _context.Customers.FirstOrDefaultAsync(u => u.UserId == user.Id);

                return customer;

           
           
        }

        public async Task<ApplicationRole> GetRoleByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }

        public async Task<ApplicationRole> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public  List<ApplicationRole> GetRoles()
        {
            return  _roleManager.Roles.ToList();
        }


        public async Task<ApplicationUsers> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUsers> GetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUsers user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public List<ApplicationUsersModelNoPassord> GetUsersAndRolesAsync()
        {
            var user = _context.Users.ToList();
            if (user == null)
                return null;
            List < ApplicationUsersModelNoPassord > users = new List<ApplicationUsersModelNoPassord>();
            foreach (var u in user)
            {
                users.Add(new ApplicationUsersModelNoPassord()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Roles =  GetUserRolesAsync(u).Result.First()
                });
            }
            return users;
        }

        

        public async Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(ApplicationUsers user)
        {

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());
            
            return (true, new string[] { });
        }

        public async Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(ApplicationUsers user, string password)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());
            result = await _userManager.RemovePasswordAsync(user);
                if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            result = await _userManager.AddPasswordAsync(user, password);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            return (true, new string[] { });
        }
    }
}
