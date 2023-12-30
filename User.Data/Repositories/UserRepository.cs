using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User.Data.DbContext;
using User.Data.DBO;
using User.UseCases.Entities;
using User.UseCases.Repositories.Interfaces;

namespace User.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _context = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<UserEntity?> GetUserById(string id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user != null) return _mapper.Map<UserEntity>(user);

        var dbo = new UserDBO
        {
            Id = id,
        };
        var newUser = await _context.Users.AddAsync(dbo);

        try
        {
            await _context.SaveChangesAsync();
            user = newUser.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return _mapper.Map<UserEntity>(user);
    }

    public async Task<IEnumerable<UserEntity>> SearchUserByName(string? searchValue, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        var query = _context.Users.AsQueryable();

        if (searchValue != null)
        {
            query = query.Where(t => t.UserName.Contains(searchValue));
        }

        return _mapper.Map<UserEntity[]>(await query.Skip(skip).Take(pageSize).ToArrayAsync());
    }

    public async Task<bool> AddUser(UserEntity entity)
    {
        _context.Users.Add(_mapper.Map<UserDBO>(entity));
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteUser(string id)
    {
        return await _context.Users.Where(x => x.Id == id).ExecuteDeleteAsync() == 1;
    }
}