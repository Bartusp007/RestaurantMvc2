using System;
using Calendar.Model;

namespace Calendar.Data.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
        ReservationContext Init();
    }
}
