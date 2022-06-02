using AutoMapper;
using System;
using Electronic_department.Application.Common.Mappings;
using Electronic_department.Application.Electronic_department.Commands.UpdateNote;

namespace Electronic_department.WebApi.Models
{
    public class UpdateElectDto : IMapWith<UpdateElectCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateElectDto, UpdateElectCommand>()
                .ForMember(electCommand => electCommand.Id,
                    opt => opt.MapFrom(electDto => electDto.Id))
                .ForMember(electCommand => electCommand.Title,
                    opt => opt.MapFrom(electDto => electDto.Title))
                .ForMember(electCommand => electCommand.Details,
                    opt => opt.MapFrom(electDto => electDto.Details));
        }
    }
}
