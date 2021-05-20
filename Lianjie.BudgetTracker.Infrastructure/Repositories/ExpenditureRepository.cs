using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Entities;
using Lianjie.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using Lianjie.BudgetTracker.Infrastructure.Data;

namespace Lianjie.BudgetTracker.Infrastructure.Repositories
{
    public class ExpenditureRepository : EfRepository<Expenditure>, IExpenditureRepository
    {
        public ExpenditureRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
