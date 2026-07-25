using AutoMapper;
using CrudBackend.Entities;

namespace CrudBackend.Features.EmployeeFeature
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper() {
            CreateMap<Employee, AddOrUpdateEmployeeRepresentationModel>()
                 .ForMember(dest => dest.name, cfg => cfg.MapFrom(src => src.Name))
                 .ForMember(dest => dest.age, cfg => cfg.MapFrom(src => src.Age))
                 .ForMember(dest => dest.city, cfg => cfg.MapFrom(src => src.City))
                 .ForMember(dest => dest.isMarried, cfg => cfg.MapFrom(src => src.IsMarried))
                 .ForMember(dest => dest.birthday, cfg => cfg.MapFrom(src => src.BirthDay))
                 .ForMember(dest => dest.gender, cfg => cfg.MapFrom(src => src.Gender));

            CreateMap<AddOrUpdateEmployeeRepresentationModel, Employee>()
     .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.name))
     .ForMember(dest => dest.Age, cfg => cfg.MapFrom(src => src.age))
     .ForMember(dest => dest.City, cfg => cfg.MapFrom(src => src.city))
     .ForMember(dest => dest.IsMarried, cfg => cfg.MapFrom(src => src.isMarried))
     .ForMember(dest => dest.BirthDay, cfg => cfg.MapFrom(src => src.birthday))
     .ForMember(dest => dest.Gender, cfg => cfg.MapFrom(src => src.gender));

            CreateMap<Employee, EmployeeRepresentationModel>()
     .ForMember(dest => dest.name, cfg => cfg.MapFrom(src => src.Name))
     .ForMember(dest => dest.age, cfg => cfg.MapFrom(src => src.Age))
     .ForMember(dest => dest.city, cfg => cfg.MapFrom(src => src.City))
     .ForMember(dest => dest.isMarried, cfg => cfg.MapFrom(src => src.IsMarried))
     .ForMember(dest => dest.birthday, cfg => cfg.MapFrom(src => src.BirthDay))
     .ForMember(dest => dest.gender, cfg => cfg.MapFrom(src => src.Gender))
     .ForMember(dest => dest.addresses, cfg => cfg.MapFrom(src => src.Addresses));

            CreateMap<EmployeeRepresentationModel, Employee>()
     .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => src.name))
     .ForMember(dest => dest.Age, cfg => cfg.MapFrom(src => src.age))
     .ForMember(dest => dest.City, cfg => cfg.MapFrom(src => src.city))
     .ForMember(dest => dest.IsMarried, cfg => cfg.MapFrom(src => src.isMarried))
     .ForMember(dest => dest.BirthDay, cfg => cfg.MapFrom(src => src.birthday))
     .ForMember(dest => dest.Gender, cfg => cfg.MapFrom(src => src.gender))
     .ForMember(dest => dest.Addresses, cfg => cfg.MapFrom(src => src.addresses));


        }
    }
}
