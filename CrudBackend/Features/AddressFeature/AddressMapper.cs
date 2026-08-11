using AutoMapper;
using CrudBackend.Entities;

namespace CrudBackend.Features.AddressFeature
{
    public class AddressMapper : Profile
    {
        public AddressMapper() {
            CreateMap<Addresses, AddOrUpdateAddressRepresentationalModel>()
                 .ForMember(dest => dest.street, tx => tx.MapFrom(src => src.Street))
                 .ForMember(dest => dest.apartment, tx => tx.MapFrom(src => src.Apartment))
                 .ForMember(dest => dest.buildingNo, tx => tx.MapFrom(src => src.BuildingNo))
                 .ForMember(dest => dest.id, tx => tx.MapFrom(src => src.AddressId));
            CreateMap<AddOrUpdateAddressRepresentationalModel, Addresses>()
     .ForMember(dest => dest.Street, tx => tx.MapFrom(src => src.street))
     .ForMember(dest => dest.Apartment, tx => tx.MapFrom(src => src.apartment))
     .ForMember(dest => dest.BuildingNo, tx => tx.MapFrom(src => src.buildingNo))
                      .ForMember(dest => dest.AddressId, tx => tx.MapFrom(src => src.id));


            CreateMap<Addresses, AddressRepresentationalModel>()
                     .ForMember(dest => dest.addressId, tx => tx.MapFrom(src => src.AddressId))
     .ForMember(dest => dest.employeeId, tx => tx.MapFrom(src => src.EmployeeId))
     .ForMember(dest => dest.street, tx => tx.MapFrom(src => src.Street))
     .ForMember(dest => dest.apartment, tx => tx.MapFrom(src => src.Apartment))
     .ForMember(dest => dest.buildingNo, tx => tx.MapFrom(src => src.BuildingNo));
            CreateMap<AddressRepresentationalModel, Addresses>()
                                     .ForMember(dest => dest.AddressId, tx => tx.MapFrom(src => src.addressId))
     .ForMember(dest => dest.EmployeeId, tx => tx.MapFrom(src => src.employeeId))
     .ForMember(dest => dest.Street, tx => tx.MapFrom(src => src.street))
     .ForMember(dest => dest.Apartment, tx => tx.MapFrom(src => src.apartment))
     .ForMember(dest => dest.BuildingNo, tx => tx.MapFrom(src => src.buildingNo));

        }
    }
}
