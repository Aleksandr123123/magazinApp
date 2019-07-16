using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Servieces.Interfaces
{
    public interface ICustomerServieces
    {
         List<CustomerViewModel> GetCustomersListToViewModel();


         CustomerViewModel GetCustomersDBToViewModelById(int customersId);

        Task<CustomerViewModel> CreateCustomer(CustomerCreateModel customer);
        CustomerUpdateModel UpdateCustomer(CustomerUpdateModel customer);
        Task<ApplicationUsersUpdateModel> UpdateUser(ApplicationUsersUpdateModel user);
        Task<ApplicationUsersModel> CreateUser(ApplicationUsersModel user);
        Task DeleteCustomer(int id);
        Task DeleteUser(string id);

    }
}
