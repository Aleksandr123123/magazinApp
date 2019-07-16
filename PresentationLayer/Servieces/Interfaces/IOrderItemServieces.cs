using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Servieces.Interfaces
{
    public interface IOrderItemServieces
    {
        OrderItemViewModel GetOrderItemModelById(int orderItemId);
        List<OrderItemViewModel> GetOrderItemsModelByOrder(int orderId);
        OrderItemViewModel SaveOrderItemCreateModelToDb(OrderItemCreateModel createModel);

    }
}
