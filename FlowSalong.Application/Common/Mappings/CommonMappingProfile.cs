using AutoMapper;
using FlowSalong.Application.Features.Customers.DTOs;
using FlowSalong.Domain.Entities;

namespace FlowSalong.Application.Common.Mappings
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
         
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();

           
        }
    }
}
