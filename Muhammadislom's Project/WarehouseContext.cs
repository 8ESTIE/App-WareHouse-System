using Muhammadislom_s_Project.EntityConfigurations;
using System;
using System.Data.Entity;
using System.Linq;

namespace Muhammadislom_s_Project
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext()
            : base("name=WarehouseContext"){}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ImportConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}