using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Entities;
using Lianjie.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using Lianjie.BudgetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lianjie.BudgetTracker.Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.Include(u => u.Expenditures).Include(u => u.Incomes).FirstOrDefaultAsync(u => u.Id == id);
        }

        public virtual async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures).FirstOrDefaultAsync(u => u.Email == email);
        }


    }
}
