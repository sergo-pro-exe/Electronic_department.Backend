using System;
using AutoMapper;
using Electronic_department.Application.Common.Mappings;
using Electronic_department.Domain;

namespace Electronic_department.Application.Electronic_department.Queries.GetElectDetails
{
    public class ElectDetailsVm : IMapWith<Elect>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Elect, ElectDetailsVm>()
                .ForMember(electVm => electVm.Title,
                    opt => opt.MapFrom(elect => elect.Title))
                .ForMember(electVm => electVm.Details,
                    opt => opt.MapFrom(elect => elect.Details))
                .ForMember(electVm => electVm.Id,
                    opt => opt.MapFrom(elect => elect.Id))
                .ForMember(electVm => electVm.CreationDate,
                    opt => opt.MapFrom(elect => elect.CreationDate))
                .ForMember(electVm => electVm.EditDate,
                    opt => opt.MapFrom(elect => elect.EditDate));
        }
    }
}
