using KitchenBook.Domain.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KitchenBook.Infrastructure.Data.UserModel;

public class UserRepository : IUserRepository
{
    private readonly KitchenBookDbContext _dbContext;

    public UserRepository(KitchenBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetById(int id)
    {
        return await _dbContext.User.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User> GetByLogin(string login)
    {
        return await _dbContext.User.SingleOrDefaultAsync(x => x.Login == login);
    }

    public async Task<User> Add(User user)
    {
        EntityEntry<User> entity = await _dbContext.User.AddAsync(user);
        return entity.Entity;
    }

    public void Update(User user)
    {
        _dbContext.User.Update(user);
    }
}
