using User.UseCases.Entities;

namespace User.UseCases.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserEntity?> GetUserById(Guid id);
    Task<IEnumerable<UserEntity>> SearchUserByName(string? searchValue, int page, int pageSize);
    Task<bool> AddUser(UserEntity entity);
    Task<bool> DeleteUser(Guid id);
}