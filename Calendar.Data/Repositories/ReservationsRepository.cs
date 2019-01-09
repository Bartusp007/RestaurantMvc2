using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Calendar.Data.Infrastructure;
using Calendar.Model;

namespace Calendar.Data.Repositories
{
    public class ReservationsRepository : RepositoryBase<Reservation>, IReservationsRepository
    {
        public ReservationsRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        /// <summary>
        /// Cos tam
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tebleList"></param>
        public void Add(Reservation entity, List<Table> tebleList)
        {
            entity.Table = tebleList;
            base.Add(entity);
        }

        public List<Reservation> GetAllTables()
        {
            var returnList = DbContext.Reseervations.Include(a => a.Table).ToList();
            return returnList;
        }

        public List<Reservation> GetManyTables(Expression<Func<Reservation, bool>> where)
        {
            var returnList = DbContext.Reseervations.Include(a => a.Table).Where(where).ToList();
            return returnList;
        }
    }
}

