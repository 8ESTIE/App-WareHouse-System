using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhammadislom_s_Project
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Import> Imports { get; set; }
        public ICollection<Product> Products { get; set; }
        public Supplier()
        {
            Imports = new List<Import>();
            Products = new List<Product>();
        }
    }
}
