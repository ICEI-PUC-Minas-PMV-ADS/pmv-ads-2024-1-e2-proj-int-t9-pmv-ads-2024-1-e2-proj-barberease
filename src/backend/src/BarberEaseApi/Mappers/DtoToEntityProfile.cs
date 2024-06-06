using AutoMapper;
using BarberEaseApi.Dtos.Appointment;
using BarberEaseApi.Dtos.Client;
using BarberEaseApi.Dtos.Establishment;
using BarberEaseApi.Dtos.EstablishmentService;
using BarberEaseApi.Entities;

namespace BarberEaseApi.Mappers
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            #region Client
            CreateMap<ClientDto, ClientEntity>().ReverseMap();
            CreateMap<ClientDtoCreate, ClientEntity>().ReverseMap();
            CreateMap<ClientDtoUpdate, ClientEntity>().ReverseMap();
            #endregion

            #region Establishment
            CreateMap<EstablishmentDto, EstablishmentEntity>().ReverseMap();
            CreateMap<EstablishmentDtoCreate, EstablishmentEntity>().ReverseMap();
            CreateMap<EstablishmentDtoUpdate, EstablishmentEntity>().ReverseMap();
            #endregion

            #region Appointment
            CreateMap<AppointmentDto, AppointmentEntity>().ReverseMap();
            CreateMap<AppointmentDetailsDto, AppointmentEntity>().ReverseMap();
            CreateMap<AppointmentCreateDto, AppointmentEntity>().ReverseMap();
            CreateMap<AppointmentUpdateDto, AppointmentEntity>().ReverseMap();
            #endregion

            #region EstablishmentService
            CreateMap<EstablishmentServiceDto, EstablishmentServiceEntity>().ReverseMap();
            CreateMap<EstablishmentServiceDetailsDto, EstablishmentServiceEntity>().ReverseMap();
            CreateMap<EstablishmentServiceCreateDto, EstablishmentServiceEntity>().ReverseMap();
            CreateMap<EstablishmentServiceUpdateDto, EstablishmentServiceEntity>().ReverseMap();
            #endregion
        }
    }
}
