using AutoMapper;
using User.UseCases.Entities;
using User.UseCases.Requests.User;
using User.UseCases.Responses;

namespace User.UseCases.Mappings;

public class ActivityMapping: Profile
{
    public ActivityMapping()
    {
        CreateMap<UpdateUserRequest, UserEntity>();
        CreateMap<UserEntity, UpdateUserResponse>();
        CreateMap<UserEntity, GetUserResponse>();
        CreateMap<GetUserResponse, UserEntity>();
    }
}