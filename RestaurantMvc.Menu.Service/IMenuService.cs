using System.Collections.Generic;
using RestaurantMvc.Model.Models;

namespace RestaurantMvc.Menu.Service
{
    public interface IMenuService
    {
        List<MenuDishes> GetDishesesByCategory(string menuCategory);
        List<MenuCategory> GetCategory();
        void AddDishes(MenuDishes dishes);
        string GetCetgoryById(int categoryId);
        void DeleteDishes(int id);
        MenuDishes GetDishesById(int? id);
        void EditDishes(MenuDishes dishes);
    }
}