using RestaurantMvc.Model.Models;

namespace RestaurantMvc.ViewModel.ViewModels
{
    public class MenuDishesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
}