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
    public class ItemRepository: IItemRepository
    {
        private EFDBContext db;

        public ItemRepository(EFDBContext context)
        {
            this.db = context;
        }

        public void Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Item item = db.Items.Find(id);
            if(item!= null)
            {
                db.Items.Remove(item);
                db.SaveChanges();
            }
        }

        public Item Get(int id)
        {
            return  db.Items.Include(o => o.OrderItems).FirstOrDefault(c => c.Id == id); ;
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Items.Include(i=> i.OrderItems);
        }

        public void Update(Item item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
