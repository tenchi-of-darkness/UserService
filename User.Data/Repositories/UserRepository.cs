using AutoMapper;
using Microsoft.EntityFrameworkCore;
using User.Data.DbContext;
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

    public async Task<UserEntity?> GetUserById(Guid id)
    {
        var activity = await _context.Activities.FindAsync(id);
        return _mapper.Map<UserEntity>(activity);
    }

    public async Task<IEnumerable<UserEntity>> SearchUserByName(string? searchValue, int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        var query = _context.Activities.AsQueryable();

        if (searchValue != null)
        {
            query = query.Where(t => t.Name.Contains(searchValue));
        }

        return _mapper.Map<UserEntity[]>(await query.Skip(skip).Take(pageSize).ToArrayAsync());
    }

    public async Task<bool> AddUser(UserEntity entity)
    {
        throw new NotImplementedException(); 
   
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        return await _context.Activities.Where(a => a.Id == id).ExecuteDeleteAsync()==1;
    }
}