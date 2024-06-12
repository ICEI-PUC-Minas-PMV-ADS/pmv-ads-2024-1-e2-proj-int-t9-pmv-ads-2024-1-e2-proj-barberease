using AutoMapper;
using BarberEaseApi.Dtos.Appointment;
using BarberEaseApi.Dtos.Client;
using BarberEaseApi.Dtos.Establishment;
using BarberEaseApi.Dtos.EstablishmentPeriod;
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
            CreateMap<ClientCreateDto, ClientEntity>().ReverseMap();
            CreateMap<ClientUpdateDto, ClientEntity>().ReverseMap();
            #endregion

            #region Establishment
            CreateMap<EstablishmentDto, EstablishmentEntity>().ReverseMap();
            CreateMap<EstablishmentCreateDto, EstablishmentEntity>().ReverseMap();
            CreateMap<EstablishmentUpdateDto, EstablishmentEntity>().ReverseMap();
            CreateMap<EstablishmentDetailsDto, EstablishmentEntity>().ReverseMap();
            #endregion

            #region Appointment
            CreateMap<AppointmentDto, AppointmentEntity>().ReverseMap();
            CreateMap<AppointmentDetailsDto, AppointmentEntity>().ReverseMap();
            CreateMap<AppointmentCreateDto, AppointmentEntity>().ReverseMap();
            #endregion

            #region EstablishmentService
            CreateMap<EstablishmentServiceDto, EstablishmentServiceEntity>().ReverseMap();
            CreateMap<EstablishmentServiceDetailsDto, EstablishmentServiceEntity>().ReverseMap();
            CreateMap<EstablishmentServiceCreateDto, EstablishmentServiceEntity>().ReverseMap();
            CreateMap<EstablishmentServiceUpdateDto, EstablishmentServiceEntity>().ReverseMap();
            #endregion

            #region EstablishmentPeriod
            CreateMap<EstablishmentPeriodDto, EstablishmentPeriodEntity>().ReverseMap();
            CreateMap<EstablishmentPeriodCreateDto, EstablishmentPeriodEntity>().ReverseMap();
            CreateMap<EstablishmentPeriodUpdateDto, EstablishmentPeriodEntity>().ReverseMap();
            #endregion
        }
    }
}
