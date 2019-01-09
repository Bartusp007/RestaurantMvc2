using System.Data.Entity.ModelConfiguration;

using RestaurantMvc.Model.Models;

namespace RestaurantMvc.Data.Configurations
{
    public class MenuDishesConfigurations:EntityTypeConfiguration<MenuDishes>
    {
        public MenuDishesConfigurations()
        {
            ToTable("MenuDishes");
            HasKey(m => m.Id);

            Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(50);

            Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(1000);
            Property(m => m.Price)
                .IsRequired();
        }


    }
}