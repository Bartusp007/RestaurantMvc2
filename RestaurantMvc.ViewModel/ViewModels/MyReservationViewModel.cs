using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMvc.ViewModel.ViewModels
{
    public class MyReservationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "From")]
        public TimeSpan FromWhatTime { get; set; }
        [Display(Name = "To")]
        public TimeSpan ToWhatTime { get; set; }
        [Display(Name = "Date")]
        public string ReservationDate { get; set; }
        [Display(Name = "For how many peoples")]
        public int HowManyPeoples { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}
