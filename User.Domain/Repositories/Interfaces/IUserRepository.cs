using User.UseCases.Entities;

namespace User.UseCases.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserEntity?> GetUserById(string id);
    Task<IEnumerable<UserEntity>> SearchUserByName(string? searchValue, int page, int pageSize);
    Task<bool> UpdateUser(UserEntity entity);
    Task<bool> DeleteUser(string id);
}