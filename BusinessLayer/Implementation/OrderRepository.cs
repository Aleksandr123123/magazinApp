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
    public class OrderRepository:IOrderRepository
    {
        private EFDBContext db;

        public OrderRepository(EFDBContext context)
        {
            this.db = context;
        }

        public int Count()
        {
            
            return db.Orders.Count();
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public Order Get(int id)
        {
            return db.Orders.Include(o => o.Customer).Include(o => o.OrderItems).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o=>o.Customer).Include(o=>o.OrderItems);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
