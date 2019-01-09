using System;
using System.Collections.Generic;
using Calendar.Data.Infrastructure;
using Calendar.Model;

namespace Calendar.Data.Repositories
{
    public interface ITableRepository:IRepository<Table>
    {
        List<Table> TablesEager();
    }
}