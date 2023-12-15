using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhammadislom_s_Project.EntityConfigurations
{
    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            Property(c => c.Name)
                .IsRequired();
        }
    }
}
