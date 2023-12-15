using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Muhammadislom_s_Project.EntityConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(c => c.Name)
                .IsRequired();

            //HasMany(p => p.Suppliers)
            //    .WithMany(s => s.Products);
        }
    }
}
