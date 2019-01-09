using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RestaurantMvc.ViewModel.ViewModels
{
    public class EditMenuViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategoryName { get; set; }
        [Required(ErrorMessage = "Ples entry new name of dishes.")]
        [Display(Name = "Dishes name:")]
        public string DishesName { get; set; }
        [Required(ErrorMessage = "Pleas enter new description of the choosen dishes.")]
        [Display(Name = "Dishes: description:")]
        public string DishesDescription { get; set; }
        [Required(ErrorMessage = "Pleas enter new price.")]
        [Display(Name = "Price:")]
        public int Price { get; set; }
    }
}