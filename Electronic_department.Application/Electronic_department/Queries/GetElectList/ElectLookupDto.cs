using AutoMapper;
using System;
using Electronic_department.Application.Common.Mappings;
using Electronic_department.Domain;

namespace Electronic_department.Application.Electronic_department.Queries.GetElectList
{
    public class ElectLookupDto : IMapWith<Elect>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Elect, ElectLookupDto>()
                .ForMember(electDto => electDto.Id,
                    opt => opt.MapFrom(elect => elect.Id))
                .ForMember(electDto => electDto.Title,
                    opt => opt.MapFrom(elect => elect.Title));
        }
    }
}
