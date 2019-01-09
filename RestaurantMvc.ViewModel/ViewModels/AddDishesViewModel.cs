using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RestaurantMvc.ViewModel.ViewModels
{
    public class AddDishesViewModel
    {
        [Required(ErrorMessage = "Please enter name of the dishes.")]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter description of the dishes.")]
        [Display(Name = "Description:")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter price of the dishes.")]
        [Display(Name = "Price:")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter value greten then 0")]
        public int Price  { get; set; }

        public IEnumerable<SelectListItem> Category { get; set; }
        [Display(Name = "Category:")]
        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
    }
}