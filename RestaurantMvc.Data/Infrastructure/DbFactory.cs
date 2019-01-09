namespace RestaurantMvc.Data.Infrastructure
{
    public class DbFactory:Disposable, IDbFactory
    {
        private ReservationContext _dbContext;
        public ReservationContext Init()
        {
            return _dbContext ?? (_dbContext = new ReservationContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
