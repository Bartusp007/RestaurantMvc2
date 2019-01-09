using System.Runtime.InteropServices;
using AutoMapper;
using RestaurantMvc.Model;
using RestaurantMvc.Model.Models;
using RestaurantMvc.ViewModel.ViewModels;

namespace RestaurantMvc.ViewModel.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappingProfile";

        public DomainToViewModelMappingProfile()
        {
            CreateMap<MenuDishes, MenuDishesViewModel>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(g => g.Category, map => map.MapFrom((vm => vm.Category.Name)));

            CreateMap<Reservation, MyReservationViewModel>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(g => g.FromWhatTime, map => map.MapFrom(vm => vm.FromWhatTime))
                .ForMember(g => g.ToWhatTime, map => map.MapFrom(vm => vm.ToWhatTime))
                .ForMember(g => g.HowManyPeoples, map => map.MapFrom(vm => vm.HowManyPeoples))
                .ForMember(g => g.PhoneNumber, map => map.MapFrom(vm => vm.PhoneNumber))
                .ForMember(g => g.Surname, map => map.MapFrom(vm => vm.Surname))
                .ForMember(g => g.ReservationDate, map => map.MapFrom(vm => vm.ReservationDate.Value.ToString("d")))
                .ForMember(g => g.UserId, map => map.MapFrom(vm => vm.UserId));
            CreateMap<MenuDishes, EditMenuViewModel>()
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.CategoryId, map => map.MapFrom(vm => vm.CategoryId))
                .ForMember(g => g.DishesDescription, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.Price))
                .ForMember(g => g.DishesName, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.CategoryName, map => map.Ignore());


        }

    }


}