using System.Collections.Generic;
using RestaurantMvc.Model.Models;

namespace RestaurantMvc.Reservation.Service
{
    public class RequestAvaibility
    {
        public bool IsAvailable;
        public List<Table> TableList;

        public RequestAvaibility()
        {
            TableList = new List<Table>();
            TableList.Clear();
        }
    }
}
