using RestaurantMvc.ViewModel.Mapping;

namespace RestaurantMvc.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
    }
}