using System;
using System.Collections.Generic;

namespace RestaurantMvc.Model.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public TimeSpan FromWhatTime { get; set; }
        public TimeSpan ToWhatTime { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int HowManyPeoples { get; set; }
        public virtual ICollection<Table> Table { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }

     

    }

   

   
}
