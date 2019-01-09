using System.Data.Entity.ModelConfiguration;
using RestaurantMvc.Model.Models;

namespace RestaurantMvc.Data.Configurations
{
    public class TablesConfigurations :  EntityTypeConfiguration<Table>
    {
        public TablesConfigurations()
        {
            ToTable("Table");
            HasKey(c => c.TableId);

            Property(c => c.Capacity)
                .IsRequired();
        }

    }
}
