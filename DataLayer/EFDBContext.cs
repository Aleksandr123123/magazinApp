using DataLayer.Entityes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class EFDBContext : IdentityDbContext<ApplicationUsers,ApplicationRole,string>
    //public class EFDBContext : DbContext
    { 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

       
        public EFDBContext(DbContextOptions<EFDBContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.Entity<Customer>().HasOne(u => u.User).WithMany(t => t.Customers).OnDelete(DeleteBehavior.Cascade);
          }

       
    }
    

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=magazinlocaldb;Trusted_Connection=True;MultipleActiveResultSets=true",b=>b.MigrationsAssembly("DataLayer"));
            return new EFDBContext(optionsBuilder.Options);
        }

    }

}
