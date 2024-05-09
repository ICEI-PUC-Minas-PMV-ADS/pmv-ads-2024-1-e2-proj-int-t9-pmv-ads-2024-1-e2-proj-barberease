using AutoMapper;
using BarberEaseApi.Dtos.Client;
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
        }
    }
}
