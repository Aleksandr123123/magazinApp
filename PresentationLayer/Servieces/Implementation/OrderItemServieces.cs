using BusinessLayer;
using DataLayer.Entityes;
using PresentationLayer.Models;
using PresentationLayer.Servieces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Servieces.Implementation
{
    public class OrderItemServieces : IOrderItemServieces
    {
        private UnitOfWork _unitOfWork;
        private IItemServieces _itemServieces;

        public OrderItemServieces(UnitOfWork unitOfWork, IItemServieces itemServieces)
        {
            _unitOfWork = unitOfWork;
            _itemServieces = itemServieces;
        }

        public OrderItemViewModel GetOrderItemModelById(int orderItemId)
        {
            var orderItem = _unitOfWork.OrderItems.Get(orderItemId);
            var itemView = _itemServieces.GetItemsDBToViewModelById(orderItem.ItemId);

            var model = new OrderItemViewModel()
            {
                Id = orderItem.Id,
                Items = itemView,
                ItemsCount = orderItem.ItemsCount,
                ItemPrice = orderItem.ItemPrice
                
            };
            
            return model;
        }

        public List<OrderItemViewModel> GetOrderItemsModelByOrder(int orderId)
        {
            var order = _unitOfWork.Orders.Get(orderId);
            List<OrderItemViewModel> model = new List<OrderItemViewModel>();
             foreach(var i  in order.OrderItems)
            {
                model.Add(GetOrderItemModelById(i.Id));
            }
            return model;
        }

        public OrderItemViewModel SaveOrderItemCreateModelToDb(OrderItemCreateModel createModel)
        {
            OrderItem orderItem = new OrderItem()
            {
                ItemId = createModel.Item.Id,
                OrderId = createModel.OrderId,
                ItemsCount = createModel.ItemsCount,
                ItemPrice = createModel.ItemPrice
            };
            _unitOfWork.OrderItems.Create(orderItem);
            return GetOrderItemModelById(orderItem.Id);
        }
    }
}
