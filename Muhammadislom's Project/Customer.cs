using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhammadislom_s_Project
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<Order> Orders { get; set; }

        public Customer()
        {
            this.Orders = new List<Order>();
        }
    }
}
