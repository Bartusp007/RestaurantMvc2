using AutoMapper;
using RestaurantMvc.Model.Models;
using RestaurantMvc.ViewModel.ViewModels;

namespace RestaurantMvc.ViewModel.Mapping
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public override string ProfileName => "ViewModelToDomainMappingProfile";

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AddDishesViewModel, MenuDishes>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(g => g.CategoryId, map => map.MapFrom(vm => vm.CategoryId));
            CreateMap<EditMenuViewModel, MenuDishes>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.DishesName))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.DishesDescription))
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(g => g.CategoryId, map => map.MapFrom(vm => vm.CategoryId));

        }
    }
}