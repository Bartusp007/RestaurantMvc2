using System;
using System.Collections.Generic;
using System.Text;
using RestaurantMvc.Model.Models;
using RestaurantMvc.ViewModel.ViewModels;

namespace RestaurantMvc.Reservation.Service
{
    public interface IServiceReservation
    {
        bool ReserveTable(ReservationViewModel reservationData);
        StringBuilder DisplayReservation(DateTime date);
        bool CheckPreReservation(PreReservationViewModel preReservation);
        List<Table> GetAvailable(PreReservationViewModel preReservation);
        IEnumerable<Model.Models.Reservation> GetReservationByUserId(string userId);
    }
}