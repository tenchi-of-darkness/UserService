using AutoMapper;
using User.Data.DBO;
using User.UseCases.Entities;

namespace User.Data.Mappings;

public class ActivityDataMapping: Profile
{
    public ActivityDataMapping()
    {
        CreateMap<UserDBO, UserEntity>();
        CreateMap<UserEntity, UserDBO>();
    }
}