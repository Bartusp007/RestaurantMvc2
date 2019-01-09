using System;
using System.ComponentModel.DataAnnotations;
using RestaurantMvc.Model.Models;
using RestaurantMvc.ViewModel.ValidationAttribute;

namespace RestaurantMvc.ViewModel.ViewModels
{

    public class ReservationViewModel
    {
        [Required(ErrorMessage = "Please choose start time for your reservation")]
        [Display(Name = "From what time:")]
        [Range(typeof(TimeSpan), "12:00", "23:00", ErrorMessage = "Restaurant is open between 12:00 and 23:00.")]
        [MinDateReservation(nameof(ToWhatTime),ErrorMessage = "Not valid time reservation.")]
        public TimeSpan FromWhatTime { get; set; }

        [Required(ErrorMessage = "Please choose end time for your reservation")]
        [Display(Name = "To what time:")]
        [Range(typeof(TimeSpan), "12:00", "23:00", ErrorMessage = "Restaurant is open between 12:00 and 23:00.")]
        [MaxDateReservation(nameof(FromWhatTime), ErrorMessage = "Notvalid time reservation.")]
        public TimeSpan ToWhatTime { get; set; }

        [Required(ErrorMessage = "Please choose date for your reservation")]
        [Display(Name = "Date:")]
        public DateTime? ReservationDate { get; set; }

        [Required(ErrorMessage = "Plese choose choose for how many people you want reservation")]
        [Display(Name = "How many people:")]
        [Range(1,40, ErrorMessage = "You can make reservation between 1 and 40 peoples.")]
        public int HowManyPeoples { get; set; }

        [Required(ErrorMessage = "Please enetr your name")]
        [Display(Name = "Full name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your surname")]
        [Display(Name = "Last name:")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please your email")]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(9)]
        [Required(ErrorMessage = "Your phone number should contain 9 digits")]
        [Display(Name = "Phone number:")]
        public string PhoneNumber { get; set; }

        public OutputMessage Status { get; set; }
        public string UserId { get; set; }

       
        public Reservation UpdateModel(Reservation reservation)
        {

            reservation.FromWhatTime = FromWhatTime;
            reservation.ToWhatTime = ToWhatTime;
            reservation.ReservationDate = ReservationDate;
            reservation.HowManyPeoples = HowManyPeoples;
            reservation.Name = Name;
            reservation.Surname = Surname;
            reservation.Email = Email;
            reservation.PhoneNumber = PhoneNumber;
            reservation.UserId = UserId;
            return reservation;
        }
        public PreReservationViewModel UpdatePreReservation()
        {
            PreReservationViewModel preReservation = new PreReservationViewModel
            {
                FromWhatTime = FromWhatTime,
                ToWhatTime = ToWhatTime,
                HowManyPeoples = HowManyPeoples,
                ReservationDate = ReservationDate
            };
            return preReservation;
        }
    }
}

