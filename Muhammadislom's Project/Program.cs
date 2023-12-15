using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Muhammadislom_s_Project
{
    public class Program
    {
        static void AddCustomer(string name)
        {
            using (WarehouseContext context = new WarehouseContext())
            {
                var alreadyThere = context.Customers.Where(c => c.Name.Equals(name)).FirstOrDefault();
                if (alreadyThere == null)
                {
                    context.Customers.Add(new Customer() { Name = name });
                }
                context.SaveChanges();
            }
        }

        static void AddSupplier(string name)
        {
            using (WarehouseContext context = new WarehouseContext())
            {
                var alreadyThere = context.Suppliers.Where(p => p.Name == name).FirstOrDefault();
                if (alreadyThere == null)
                {
                    context.Suppliers.Add(new Supplier() { Name = name });
                }
                context.SaveChanges();
            }
        }

        static void AddImport(int quantity, decimal price, string productName, int supplierId, int producId)
        {
            using (WarehouseContext context = new WarehouseContext())
            {
                if (quantity > 0)
                {
                    var alreadyThere = context.Products.Where(p => p.Name == productName).FirstOrDefault();
                    if (alreadyThere == null)
                    {
                        Product product = new Product() { Name = productName, Price = price / quantity, Remain = quantity };
                        context.Products.Add(product);
                        alreadyThere = product;
                    }
                    context.Imports.Add(new Import()
                    { Quantity = quantity, Price = price, ProductId = producId, SupplierId = supplierId });
                    alreadyThere.Remain += quantity;
                    context.SaveChanges();
                }
            }
        }

        static void AddOrder(int quantity, decimal price, int productId, int customerId)
        {
            using (WarehouseContext context = new WarehouseContext())
            {
                var There = context.Products.Where(o => o.Id == productId).FirstOrDefault();
                if (There == null) throw new InvalidOperationException("Ware is not in the warehouse");
                context.Orders.Add(new Order() { Quantity = quantity, Price = price, CustomerId = customerId, ProductId = productId });
                There.Remain -= quantity;
                context.SaveChanges();
            }
        }

        static decimal GetOutlay()
        {
            using (WarehouseContext context = new WarehouseContext())
            {
                decimal outlay = context.Imports.Sum(i => i.Price);
                return outlay;
            }
        }

        static decimal GetProfit()
        {
            using (WarehouseContext context = new WarehouseContext())
            {
                decimal profit = context.Orders.Sum(o => o.Price);
                return profit;
            }
        }

        static void DisplayOrders()
        {
            using (WarehouseContext context = new WarehouseContext())
            {
                foreach (Order order in context.Orders)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
                    order.Id, order.CustomerId, order.ProductId, order.Quantity, order.Price);
                }
            }
        }

        static void DisplayImports()
        {
            using (WarehouseContext context = new WarehouseContext())
            {
                foreach (Import import in context.Imports)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
                    import.Id, import.SupplierId, import.ProductId, import.Quantity, import.Price);
                }
            }
        }
        
        static void Seed()
        {
            for (int i = 1; i <= 5; i++)
            {
                AddCustomer(i.ToString());
                AddSupplier(i.ToString());
                AddImport(i, i, i.ToString(), i, i);
                AddOrder(i, i, i, i);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetProfit());
            Console.WriteLine(GetOutlay());
            DisplayImports();
            DisplayOrders();
        }
    }
}
