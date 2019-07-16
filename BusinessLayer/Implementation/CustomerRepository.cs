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
    public class CustomerRepository : ICustomerRepository
    {
        private EFDBContext db;

        public CustomerRepository(EFDBContext context)
        {
            this.db = context;
        }

        public void Create(Customer item)
        {
            db.Customers.Add(item);
            db.SaveChanges();
            
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if(customer!= null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public Customer Get(int id)
        {
            return db.Customers.Include(o => o.Orders).FirstOrDefault(c => c.Id == id); ;
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.Include(o=>o.Orders);

           
        }

        public void Update(Customer item)
        {

            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
