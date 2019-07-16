using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class UnitOfWork
    {

        private ICustomerRepository _customerRepository;
        private IItemRepository _itemRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;

        public UnitOfWork(ICustomerRepository customerRepository, IItemRepository itemRepository, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _customerRepository = customerRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public ICustomerRepository Customers { get { return _customerRepository; } }
        public IItemRepository Items { get { return _itemRepository; } }
        public IOrderRepository Orders { get { return _orderRepository; } }
        public IOrderItemRepository OrderItems { get { return _orderItemRepository; } }
    }
}
