using AutoMapper;
using FlowSalong.Application.Features.Customers.DTOs;
using FlowSalong.Domain.Entities;

namespace FlowSalong.Application.Features.Customers.Mappings
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();
        }
    }
}
