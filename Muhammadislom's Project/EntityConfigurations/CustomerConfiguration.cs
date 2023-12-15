using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muhammadislom_s_Project.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.Name)
                .IsRequired();

            HasMany(c => c.Orders)
                .WithRequired(o => o.Customer)
                .WillCascadeOnDelete(false);
        }
    }
}
