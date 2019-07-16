
using BusinessLayer;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Servieces.Implementation
{
    public class CustomerServieces: ICustomerServieces
    {
        private UnitOfWork _unitOfWork;
        private IOrderServieces _orderServieces;
        private IAccountManager _accountManager;

        public CustomerServieces(UnitOfWork unitOfWork, IOrderServieces orderServieces, IAccountManager accountManager)
        {
            _unitOfWork = unitOfWork;
            _orderServieces = orderServieces;
            _accountManager = accountManager;
        }

        public List<CustomerViewModel> GetCustomersListToViewModel()
        {
            var customers = _unitOfWork.Customers.GetAll();
            List<CustomerViewModel> model = new List<CustomerViewModel>();
            foreach (var item in customers)
            {
                model.Add(GetCustomersDBToViewModelById(item.Id));
            }
            return model;
        }

        public  CustomerViewModel GetCustomersDBToViewModelById(int customersId)
        {

            var customers = _unitOfWork.Customers.Get(customersId);
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var item in customers.Orders)
            {
                orderViewModels.Add(_orderServieces.GetOrderDBModelToViewById(item.Id));
            }
            var user =  _accountManager.GetUserByIdAsync(customers.UserId.ToString());
            var model = new CustomerViewModel()
            {
                Id = customers.Id,
                Name = customers.Name,
                Code = customers.Code,
                Address = customers.Address,
                Discount = customers.Discount,
                Orders = orderViewModels,
                Users = user.Result
            };
            return model;
            
        }

        public async Task<CustomerViewModel> CreateCustomer(CustomerCreateModel customer)
        {
            ApplicationUsers user = new ApplicationUsers()
            {
                UserName = customer.Users.UserName,
                FullName = customer.Users.UserName

            };
            
           
            var result  = await _accountManager.CreateUserAsync(user,customer.Users.Roles,customer.Users.Password);

            if (result.Succeeded)
            {
                Customer customerByDB = new Customer()
                {
                    Name = customer.Name,
                    Code = customer.Code,
                    Address = customer.Address,
                    Discount = customer.Discount,
                    User = await _accountManager.GetUserByNameAsync(user.UserName)
                };
                _unitOfWork.Customers.Create(customerByDB);
                   return GetCustomersDBToViewModelById(customerByDB.Id);

                
            }
            
                return null;

             

        }

        public async Task<ApplicationUsersModel> CreateUser(ApplicationUsersModel user)
        {
            ApplicationUsers applicationUsers = new ApplicationUsers
            {
                UserName = user.UserName,
                FullName = user.UserName,
                

            };
            var result = await _accountManager.CreateUserAsync(applicationUsers, user.Roles, user.Password);
            if (!result.Succeeded)
            {
                return null;

            }
            ApplicationUsers usersByDb = await _accountManager.GetUserByNameAsync(user.UserName);

            return new ApplicationUsersModel()
            {
                Id = usersByDb.Id,
                UserName = usersByDb.UserName,
                Roles=  _accountManager.GetUserRolesAsync(usersByDb).Result.First()
               
            };

        }

        public CustomerUpdateModel UpdateCustomer(CustomerUpdateModel customer)
        {
            Customer customerByDb = _unitOfWork.Customers.Get(customer.Id);
            customerByDb.Name = customer.Name;
            customerByDb.Code = customer.Code;
            customerByDb.Address = customer.Address;
            customerByDb.Discount = customer.Discount;
            _unitOfWork.Customers.Update(customerByDb);
            return customer;
        }

        public async Task<ApplicationUsersUpdateModel> UpdateUser(ApplicationUsersUpdateModel user)
        {
            var users = await _accountManager.GetUserByIdAsync(user.Id);
            users.UserName = user.UserName;
            users.FullName = user.UserName;
            if (user.Password != null)
                 await _accountManager.UpdateUserAsync(users, user.Password);
            else
                await _accountManager.UpdateUserAsync(users);
            try
            {
                return user;
            }catch
            {
                return null;
            }
        }

        public async Task DeleteCustomer(int id)
        {
            Customer customer = _unitOfWork.Customers.Get(id);

            _unitOfWork.Customers.Delete(id);
            await _accountManager.DeleteUserAsync(await _accountManager.GetUserByIdAsync(customer.UserId));

        }

        public async Task DeleteUser(string id)
        {
            ApplicationUsers users = await _accountManager.GetUserByIdAsync(id);
            await _accountManager.DeleteUserAsync(users);
        }
    }
}
