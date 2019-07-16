using BusinessLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Servieces.Implementation
{
    public class OrderServieces:IOrderServieces
    {
        private UnitOfWork _unitOfWork;
        private IOrderItemServieces _orderItemServieces;

        public OrderServieces(UnitOfWork unitOfWork, IOrderItemServieces orderItemServieces)
        {
            _unitOfWork = unitOfWork;
            _orderItemServieces = orderItemServieces;
        }

        public void DeleteOrder(int id)
        {
            _unitOfWork.Orders.Delete(id);
        }

        public OrderViewModel GetOrderDBModelToViewById(int orderId)
        {
            var order = _unitOfWork.Orders.Get(orderId);
            var customerView = _unitOfWork.Customers.Get(order.CustomerId);

            var model = new OrderViewModel()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                ShipmentDate = order.ShipmentDate,
                OrderNumber = order.OrderNumber,
                Status = order.Status,
             
                OrderItems = _orderItemServieces.GetOrderItemsModelByOrder(order.Id)
                
            };
              return model;
        }

        public List<OrderViewModel> GetOrdersByUser(int customerId)
        {

            List<Order> order = _unitOfWork.Customers.Get(customerId).Orders;

            List<OrderViewModel> model = new List<OrderViewModel>();
            foreach (var o in order)
            {
                model.Add(GetOrderDBModelToViewById(o.Id));
            }
            return model;
            
        }

        public List<OrderViewModel> GetOrdersListToViewModel()
        {
            var orders = _unitOfWork.Orders.GetAll();
            List<OrderViewModel> model = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                model.Add(GetOrderDBModelToViewById(order.Id));
            }
            return model;
        }

        public OrderViewModel SaveOrderCreateModelToDb(OrderCreateModel createModel)
        {

            Order order = new Order()
            {
                CustomerId = createModel.CustomerId,
                OrderDate = DateTime.Now,
                Status = "Новый",
                OrderNumber = _unitOfWork.Orders.Count() + 1 * createModel.CustomerId * 10000

            };
            _unitOfWork.Orders.Create(order);
            foreach(var model in createModel.OrderItems)
            {
                model.OrderId = order.Id;
                
                _orderItemServieces.SaveOrderItemCreateModelToDb(model);
            }
            return GetOrderDBModelToViewById(order.Id);
        }

        public void UpdateOrderStatus(OrderUpdateModel model)
        {
            Order order = _unitOfWork.Orders.Get(model.Id);
            order.Status = model.Status;
            order.ShipmentDate = model.ShipmentDate;
            _unitOfWork.Orders.Update(order);
}
    }
}
