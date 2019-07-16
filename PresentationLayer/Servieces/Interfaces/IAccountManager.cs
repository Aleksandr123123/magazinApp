using DataLayer.Entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Servieces.Interfaces
{
    public interface IAccountManager
    {
        Task<(bool Succeeded, string[] Errors)> CreateUserAsync(ApplicationUsers user, string roles, string password);
        Task<ApplicationRole> GetRoleByIdAsync(string roleId);
        Task<ApplicationRole> GetRoleByNameAsync(string roleName);
        Task<ApplicationUsers> GetUserByIdAsync(string userId);
        Task<ApplicationUsers> GetUserByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(ApplicationUsers user,string password);
        Task<IList<string>> GetUserRolesAsync(ApplicationUsers user);
        Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(ApplicationUsers user);
        Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(ApplicationUsers user,string password);
        List<ApplicationUsersModelNoPassord> GetUsersAndRolesAsync();
        List<ApplicationRole> GetRoles();
        Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(ApplicationUsers user);
        Task<Customer> GetCustomerByUser(ApplicationUsers user);



    }
}
