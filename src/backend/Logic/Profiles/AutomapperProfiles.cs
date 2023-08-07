using AutoMapper;
using Models.DbModels;
using Models.DTOs.CarBrandDTOs;
using Models.DTOs.CarDTOs;
using Models.DTOs.CarModelDTOs;
using Models.DTOs.ClientDTOs;

namespace Logic.Profiles;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        //mappings for car entity
        CreateMap<Car, CarDto>()
            .ForMember(d => d.CarModelName, o =>
                o.MapFrom(c => c.CarModel.Name))
            .ForMember(d => d.CarBrandName, o =>
                o.MapFrom(c => c.CarBrand.Name));
        CreateMap<AddCarDto, Car>();
        CreateMap<UpdateCarDto, Car>();

        //mappings for client entity
        CreateMap<AddClientDto, Client>();
        CreateMap<UpdateClientDto, Client>();
        CreateMap<Client, ClientDto>();
        
        //mappings for CarBrand entity
        CreateMap<AddCarBrandDto, CarBrand>();
        CreateMap<UpdateCarBrandDto, CarBrand>();
        CreateMap<CarBrand, CarBrandDto>();
        
        //mappings for CarModel entity
        CreateMap<AddCarModelDto, CarModel>();
        CreateMap<CarModel, CarModelDto>();
    }
}
