using AutoMapper;
using NetTopologySuite.Geometries;
using User.API.DTO;
using User.UseCases.Entities;

namespace User.API.Mappings;

public class ActivityApiMapping : Profile
{
    public ActivityApiMapping()
    {
        CreateMap<UserDTO, UserEntity>()
            .ForMember(x => x.Location, x => x.MapFrom(y => new Point(y.LocationLat, y.LocationLong)));
        CreateMap<UserEntity, UserDTO>()
            .ForMember(x => x.LocationLat, x => x.MapFrom(y => y.Location.X))
            .ForMember(x => x.LocationLong, x => x.MapFrom(y => y.Location.Y));
    }
}