using AutoMapper;
using NetTopologySuite.Geometries;
using User.API.DTO;
using User.UseCases.Entities;

namespace User.API.Mappings;

public class ActivityApiMapping : Profile
{
    public ActivityApiMapping()
    {
        CreateMap<UserDTO, UserEntity>();
        CreateMap<UserEntity, UserDTO>();
    }
}