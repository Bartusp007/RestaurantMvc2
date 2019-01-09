using System.Collections.Generic;
using System.Data.Entity;
using Calendar.Model;

namespace Calendar.Data
{
    public class ReservationsSeedData : DropCreateDatabaseIfModelChanges<ReservationContext>
    {
        protected override void Seed(ReservationContext context)
        {
            GetTableses().ForEach(c => context.Tableses.Add(c));
            context.Commit();
        }
        public static List<Table> GetTableses()
        {
            return new List<Table>{
                new Table()
                {
                    TableId=1,
                    Capacity=2
                },
                  new Table()
                {
                    TableId=2,
                    Capacity=2
                },
                    new Table()
                {
                    TableId=3,
                    Capacity=4
                },
                      new Table()
                {
                    TableId=4,
                    Capacity=4
                },
                        new Table()
                {
                    TableId=5,
                    Capacity=4
                },
                          new Table()
                {
                    TableId=6,
                    Capacity=4
                },
                          new Table()
                {
                    TableId=7,
                    Capacity=6
                },
                            new Table()
                {
                    TableId=8,
                    Capacity=8
                },

            };
        }


    }
}
