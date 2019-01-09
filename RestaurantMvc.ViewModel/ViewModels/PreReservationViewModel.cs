using System;

namespace RestaurantMvc.ViewModel.ViewModels
{
    public class PreReservationViewModel
    {
        public TimeSpan FromWhatTime { get; set; }
        public TimeSpan ToWhatTime { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int HowManyPeoples { get; set; }
    }
}