using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Models.Request;
using Lianjie.BudgetTracker.ApplicationCore.Models.Response;

namespace Lianjie.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IIncomeService
    {
        Task AddIncome(IncomeRequestModel incomeRequest);
        Task DeleteIncome(int id);   
        Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel incomeRequest);
        Task<IEnumerable<IncomeResponseModel>> GetAllIncomesByUser(int id);
        Task<IEnumerable<IncomeResponseModel>> GetAllIncomes();


    }
}
