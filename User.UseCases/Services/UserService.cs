using AutoMapper;
using User.UseCases.Entities;
using User.UseCases.Repositories.Interfaces;
using User.UseCases.Requests.Activities;
using User.UseCases.Responses;
using User.UseCases.Services.Interfaces;

namespace User.UseCases.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserResponse?> GetUserById(Guid id)
    {
        return _mapper.Map<GetUserResponse>(await _userRepository.GetUserById(id));
    }

    public async Task<GetUsersResponse> GetUsers(string? searchValue, int page, int pageSize)
    {
        return new GetUsersResponse(_mapper.Map<GetUserResponse[]>(await _userRepository.SearchUserByName(searchValue, page, pageSize)));
    }

    public async Task<AddUserResponse> AddUser(AddUserRequest request)
    {
        if (request.Description?.Length >255)
        {
            return new AddUserResponse(FailureType.User,
                "Description has too many characters. Only 255 characters are allowed");
        }

        var activity = _mapper.Map<UserEntity>(request);

        // activity.OwnerUserId = 

        if (!await _userRepository.AddUser(activity))
        {
            return new AddUserResponse(FailureType.Server, "Database failure");
        }

        return new AddUserResponse();
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        return await _userRepository.DeleteUser(id);
    }
}