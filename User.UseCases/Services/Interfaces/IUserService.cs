using User.UseCases.Requests.User;
using User.UseCases.Responses;

namespace User.UseCases.Services.Interfaces;

public interface IUserService
{
    Task<GetUserResponse?> GetUser();
    Task<GetUsersResponse> GetUsers(string? searchValue, int page, int pageSize);
    Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request);
    Task<bool> DeleteUser(string id);
}