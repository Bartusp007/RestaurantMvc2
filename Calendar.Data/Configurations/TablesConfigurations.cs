using System.Data.Entity.ModelConfiguration;
using Calendar.Model;

namespace Calendar.Data.Configurations
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
