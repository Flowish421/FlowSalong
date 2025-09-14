using AutoMapper;
using FlowSalong.Domain.Entities;
using FlowSalong.Application.Features.Staffs.DTOs;

namespace FlowSalong.Application.Features.Staffs.Mappings
{
    public class StaffMappingProfile : Profile
    {
        public StaffMappingProfile()
        {
            // Domain → DTO
            CreateMap<Staff, StaffDto>();

            // DTO → Domain
            CreateMap<StaffCreateDto, Staff>();
            CreateMap<StaffUpdateDto, Staff>();
        }
    }
}
