using AutoMapper;
using BarberEaseApi.Dtos.Client;
using BarberEaseApi.Dtos.Establishment;
using BarberEaseApi.Entities;

namespace BarberEaseApi.Mappers
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<ClientDto, ClientEntity>().ReverseMap();
            CreateMap<ClientDtoCreate, ClientEntity>().ReverseMap();
            CreateMap<ClientDtoUpdate, ClientEntity>().ReverseMap();

            CreateMap<EstablishmentDto, EstablishmentEntity>().ReverseMap();
            CreateMap<EstablishmentDtoCreate, EstablishmentEntity>().ReverseMap();
            CreateMap<EstablishmentDtoUpdate, EstablishmentEntity>().ReverseMap();
        }
    }
}
