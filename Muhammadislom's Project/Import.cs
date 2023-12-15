using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhammadislom_s_Project
{
    public class Import
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
