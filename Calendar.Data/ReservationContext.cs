using System.Data.Entity;
using Calendar.Data.Configurations;
using Calendar.Model;

namespace Calendar.Data
{
    public class ReservationContext: DbContext
    {
        public DbSet<Reservation> Reseervations { get; set; }
        public DbSet<Table> Tableses { get; set; }

        public ReservationContext()
            :base("name=RestaurantDataBase")
        {
        }

        //public ReservationContext(string connestionString)
        //    : base($"name={connestionString}")
        //{
            
        //}


        public virtual void Commit()
        {
            base.SaveChanges();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReservationConfiguration());
            modelBuilder.Configurations.Add(new TablesConfigurations());
        }



    }
}
