using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calendar.Data.Infrastructure;
using Calendar.Model;

namespace Calendar.Data.Repositories
{
    public class TableRepository: RepositoryBase<Table>, ITableRepository
    {
        private readonly IDbSet<Table> _dbSet;
        public TableRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            _dbSet = DbContext.Set<Table>();
        }
        public List<Table> TablesEager()
        {
            var returnList = _dbSet.Include(t => t.Reservation).ToList();

            return returnList;
        }
    }
}
