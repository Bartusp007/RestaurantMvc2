using System.Collections.Generic;

namespace RestaurantMvc.Model.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}