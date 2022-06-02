using AutoMapper;
using Electronic_department.Application.Common.Mappings;
using Electronic_department.Application.Electronic_department.Commands.CreateNote;
using System.ComponentModel.DataAnnotations;

namespace Electronic_department.WebApi.Models
{
    public class CreateElectDto : IMapWith<CreateNoteCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateElectDto, CreateNoteCommand>()
                .ForMember(electCommand => electCommand.Title,
                    opt => opt.MapFrom(electDto => electDto.Title))
                .ForMember(electCommand => electCommand.Details,
                    opt => opt.MapFrom(electDto => electDto.Details));
        }
    }
}
