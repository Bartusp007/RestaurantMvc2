
using System.Collections.Generic;
using System.Linq;
using RestaurantMvc.Model.Models;
using RestaurantMvc.ViewModel.ViewModels;

namespace RestaurantMvc.Reservation.Service
{
    public static class TableAvabilityHelper
    {
        public static List<Table> GetFree(this List<Table> tables, PreReservationViewModel preReservation)
        {
            return tables.Where(t => t.Reservation.CheckIfFree(preReservation)).ToList();
        }

        private static bool CheckIfFree(this IEnumerable<Model.Models.Reservation> reservations,
            PreReservationViewModel preReservation)
        {
            if (reservations.Any())
            {
                var available = reservations.Where(r => r.ReservationDate == preReservation.ReservationDate &
                                                        !(r.FromWhatTime >= preReservation.ToWhatTime ||
                                                          r.ToWhatTime <= preReservation.FromWhatTime)).ToList();
                return available.Count == 0;
            }
            return true;
        }
    }
}

