using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Servieces.Interfaces
{
    public interface IOrderServieces
    {
        OrderViewModel GetOrderDBModelToViewById(int orderId);
        List<OrderViewModel> GetOrdersListToViewModel();
        OrderViewModel SaveOrderCreateModelToDb(OrderCreateModel createModel);
        List<OrderViewModel> GetOrdersByUser(int customerId);
        void DeleteOrder(int id);
        void UpdateOrderStatus(OrderUpdateModel model);
    }
}
