using System;

namespace RestaurantMvc.Data.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
        ReservationContext Init();
    }
}
