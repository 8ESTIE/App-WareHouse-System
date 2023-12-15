using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhammadislom_s_Project
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Remain { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        public Product()
        {
            Suppliers = new List<Supplier>();
        }
    }
}
