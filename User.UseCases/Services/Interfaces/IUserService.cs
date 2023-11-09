using User.UseCases.Requests.Activities;
using User.UseCases.Responses;

namespace User.UseCases.Services.Interfaces;

public interface IUserService
{
    Task<GetUserResponse?> GetUserById(Guid id);
    Task<GetUsersResponse> GetUsers(string? searchValue, int page, int pageSize);
    Task<AddUserResponse> AddUser(AddUserRequest request);
    Task<bool> DeleteUser(Guid id);
}