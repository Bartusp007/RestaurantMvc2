namespace RestaurantMvc.Model.Models
{
    public class MenuDishes
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public MenuCategory Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}