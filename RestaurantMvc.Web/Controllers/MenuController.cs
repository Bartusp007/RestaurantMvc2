using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using RestaurantMvc.Data.Repositories;
using RestaurantMvc.Menu.Service;
using RestaurantMvc.Model.Models;
using RestaurantMvc.ViewModel.ViewModels;

namespace RestaurantMvc.Web.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController()
        {
            this._menuService = new MenuService();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Category", new RouteValueDictionary(
                        new { controller = "Menu", action = "Category", category = "Zupy" }));
        }

        [AllowAnonymous]
        public ActionResult Category(string category)
        {
            if (category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Category = category;

            IEnumerable<MenuDishes> menuDisheses = _menuService.GetDishesesByCategory(category).ToList();
            var menuDishesViewModels = Mapper.Map<IEnumerable<MenuDishes>, IEnumerable<MenuDishesViewModel>>(menuDisheses);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_MenuCategoryPartialView", menuDishesViewModels);
            }
            return View(menuDishesViewModels);
        }
        [Authorize(Roles = "admin, staff")]
        public ActionResult AddCategory()
        {
            var aLlCategory = _menuService.GetCategory();
            var addNewDishes = new AddDishesViewModel { Category = aLlCategory.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name.ToString() }) };
            return View(addNewDishes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, staff")]
        public ActionResult AddCategory(AddDishesViewModel addDishesViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                var aLlCategory = _menuService.GetCategory();
                addDishesViewModel.Category =
                    aLlCategory.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name.ToString() });
                return View(addDishesViewModel);
            }

                

            var menuItem = Mapper.Map<AddDishesViewModel, MenuDishes>(addDishesViewModel);
            var categoryName = _menuService.GetCetgoryById(addDishesViewModel.CategoryId);
            try
            {

                _menuService.AddDishes(menuItem);
                return RedirectToAction("Category", new RouteValueDictionary(
                        new { controller = "Menu", action = "Category", category = categoryName }));
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirm(int id, string categoryName)
        {
            try
            {
                _menuService.DeleteDishes(id);
                return RedirectToAction("Category", new RouteValueDictionary(
                        new { controller = "Menu", action = "Category", category = categoryName }));
            }
            catch (Exception)
            {
                return View("Error");

            }
            
        }

        [HttpGet]
        [Authorize(Roles = "admin, staff")]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aLlCategory = _menuService.GetCategory();
            var dishes = _menuService.GetDishesById(id);
            var dishesViewModel = Mapper.Map<MenuDishes, EditMenuViewModel>(dishes);
            dishesViewModel.CategoryName =
                aLlCategory.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Name.ToString()});
            if (dishes==null)
            {
                return HttpNotFound();
            }

            return View(dishesViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin, staff")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditMenuViewModel menuViewModel)
        {
            if (!ModelState.IsValid) return View(menuViewModel);
            try
            {
                var menuModel = Mapper.Map<EditMenuViewModel, MenuDishes>(menuViewModel);
                _menuService.EditDishes(menuModel);
                return RedirectToAction("Category", new RouteValueDictionary(
                    new { controller = "Menu", action = "Category", category = _menuService.GetCetgoryById(menuModel.CategoryId) }));
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
    }

}