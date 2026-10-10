using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewHome.Domain.Shared;
using NewHome.Domain.Users;
using NewHome.Domain.Users.UserValueObjects;

namespace NewHome.Infrastucture.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
          _dbContext = dbContext;   
        }

        public async Task<Guid> Add(User user, CancellationToken cancellationToken = default)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

        public async Task<Result<User>> GetById(UserId userId)
        {
            var user = await _dbContext.Users
                .Include( u => u.UserPets)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null) return "User not found";

            return user;
        }
    }
}
