using RestaurantMvc.Model.Models;
using RestaurantMvc.Models.Infrastructure;

namespace RestaurantMvc.Data.Repositories
{
    public interface IManuCategoryRepository : IRepository<MenuCategory>
    {
        MenuCategory GetCategoryById(int id);
    }
}