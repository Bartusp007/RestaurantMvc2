using System.Data.Entity.ModelConfiguration;
using Calendar.Model;

namespace Calendar.Data.Configurations
{
    public class ReservationConfiguration : EntityTypeConfiguration<Reservation>
    {

        public ReservationConfiguration()
        {
            ToTable("Reservation");
            HasKey(c => c.Id);

            Property(c => c.Email)
                .HasMaxLength(50);

            Property(c => c.FromWhatTime)
                .IsRequired();

            Property(c => c.HowManyPeoples)
                .IsRequired();

            Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            Property(c => c.PhoneNumber)
                .IsRequired();

            Property(c => c.ReservationDate)
                .IsRequired();

            Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.ToWhatTime)
                .IsRequired();
        }

    }
}
