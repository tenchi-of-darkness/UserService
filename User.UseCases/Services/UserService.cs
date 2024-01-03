using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RTools_NTS.Util;
using User.UseCases.Entities;
using User.UseCases.Repositories.Interfaces;
using User.UseCases.Requests.User;
using User.UseCases.Responses;
using User.UseCases.Services.Interfaces;

namespace User.UseCases.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly HttpContext? _context;

    public UserService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _context = httpContextAccessor.HttpContext;
    }

    public async Task<GetUserResponse?> GetUser()
    {
        var userId = _context?.User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        if (userId == null)
        {
            return null;
        }

        var entity = await _userRepository.GetUserById(userId);
        return _mapper.Map<GetUserResponse>(entity);
    }

    public async Task<GetUsersResponse> GetUsers(string? searchValue, int page, int pageSize)
    {
        var entities = await _userRepository.SearchUserByName(searchValue, page, pageSize);
        return new GetUsersResponse(_mapper.Map<GetUserResponse[]>(entities));
    }

    public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
    {
        if (request.Bio?.Length > 255)
        {
            return new UpdateUserResponse(FailureType.User,
                "Bio has too many characters. Only 255 characters are allowed");
        }

        if (request.UserName.Length > 30)
        {
            return new UpdateUserResponse(FailureType.User,"User name has too many characters. Only 30 characters are allowed");
        }
        
        var userId = _context?.User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        if (userId == null)
        {
            return new UpdateUserResponse(FailureType.User, "User is not authenticated");
        }

        var entity = _mapper.Map<UserEntity>(request);

        entity.Id = userId;
        
        if (!await _userRepository.UpdateUser(entity))
            return new UpdateUserResponse(FailureType.Server, "Database failure");

        return new UpdateUserResponse();
    }

    public async Task<bool> DeleteUser(string id)
    {
        return await _userRepository.DeleteUser(id);
    }
}