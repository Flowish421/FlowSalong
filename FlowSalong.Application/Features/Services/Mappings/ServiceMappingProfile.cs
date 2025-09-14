using AutoMapper;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Domain.Entities;

namespace FlowSalong.Application.Features.Services.Mappings
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Service, ServiceCreateDto>().ReverseMap();
            CreateMap<Service, ServiceUpdateDto>().ReverseMap();
        }
    }
}
