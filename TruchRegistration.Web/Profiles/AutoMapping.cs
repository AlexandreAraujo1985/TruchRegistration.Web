using AutoMapper;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Web.ViewModels;

namespace TruckRegistration.Web.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<TruckViewModel, Truck>();
            CreateMap<Truck, TruckViewModel>();

            CreateMap<TruckModelViewModel, TruckModel>();
            CreateMap<TruckModel, TruckModelViewModel>();
        }
    }
}
