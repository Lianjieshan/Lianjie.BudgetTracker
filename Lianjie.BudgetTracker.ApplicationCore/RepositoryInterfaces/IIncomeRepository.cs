using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Entities;

namespace Lianjie.BudgetTracker.ApplicationCore.RepositoryInterfaces
{

    public interface IIncomeRepository: IAsyncRepository<Income>
    {
        // For add new method in the future
    }
}
