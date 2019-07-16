using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementation
{
    public class OrderItemRepository:IOrderItemRepository
    {
        private EFDBContext db;

        public OrderItemRepository(EFDBContext context)
        {
            this.db = context;
        }

        public void Create(OrderItem orderItem)
        {
            db.OrderItems.Add(orderItem);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem != null)
            {
                db.OrderItems.Remove(orderItem);
                db.SaveChanges();
            }
        }

        public OrderItem Get(int id)
        {
            return db.OrderItems.Include(o => o.Order).Include(o => o.Item).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return db.OrderItems.Include(o=>o.Order).Include(o=>o.Item);
        }

        public void Update(OrderItem orderItem)
        {
            db.Entry(orderItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
