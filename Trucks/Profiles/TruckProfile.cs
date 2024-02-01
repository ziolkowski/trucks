using AutoMapper;
using Trucks.Dto;
using Trucks.Model;

namespace Trucks.Profiles
{
    public class TruckProfile : Profile
    {
        public TruckProfile() 
        {
            CreateMap<Truck, TruckDto>();
            CreateMap<CreateTruckDto, Truck>();
        }
    }
}
