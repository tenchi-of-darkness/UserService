using AutoMapper;
using User.UseCases.Entities;
using User.UseCases.Requests.Activities;
using User.UseCases.Responses;

namespace User.UseCases.Mappings;

public class ActivityMapping: Profile
{
    public ActivityMapping()
    {
        CreateMap<AddUserRequest, UserEntity>();
        CreateMap<UserEntity, AddUserResponse>();
    }
}