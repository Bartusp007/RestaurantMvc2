using System.Collections.Generic;
using System.Linq;
using RestaurantMvc.Data.Infrastructure;
using RestaurantMvc.Data.Repositories;
using RestaurantMvc.Model.Models;
using RestaurantMvc.ViewModel.ViewModels;

namespace RestaurantMvc.Menu.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuDishesRepository _menuDishesRepository;
        private readonly IManuCategoryRepository _manuCategoryRepository;
        private readonly IDbFactory _dbFactory;
        private readonly IUnitOfWork _unitOfWork;

        public MenuService()
        {
            _dbFactory = new DbFactory();
            _menuDishesRepository = new MenuDishesRepository(_dbFactory);
            _manuCategoryRepository = new ManuCategoryRepository(_dbFactory);
            _unitOfWork= new UnitOfWork(_dbFactory);
        }

        public List<MenuDishes> GetDishesesByCategory(string menuCategory)
        {
            return _menuDishesRepository.GetDishes(menuCategory);
        }

        public List<MenuCategory> GetCategory()
        {
            return _manuCategoryRepository.GetAll().ToList();


        }

        public void AddDishes(MenuDishes dishes)
        {
            _menuDishesRepository.Add(dishes);
            _unitOfWork.Commit();
        }

        public string GetCetgoryById(int categoryId)
        {
            return _manuCategoryRepository.GetCategoryById(categoryId).Name;
        }

        public void DeleteDishes(int id)
        {
            _menuDishesRepository.Delete(a=>a.Id==id);
            _unitOfWork.Commit();
        }

        public MenuDishes GetDishesById(int? id)
        {
            var dishes = _menuDishesRepository.Get(d => d.Id == id);
            return dishes;
        }

        public void EditDishes(MenuDishes dishes)
        {
            _menuDishesRepository.Update(dishes);
            _unitOfWork.Commit();
        }
    }
}
