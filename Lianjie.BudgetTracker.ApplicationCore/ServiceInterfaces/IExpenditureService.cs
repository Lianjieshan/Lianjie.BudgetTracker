using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Models.Request;
using Lianjie.BudgetTracker.ApplicationCore.Models.Response;

namespace Lianjie.BudgetTracker.ApplicationCore.ServiceInterfaces
{
    public interface IExpenditureService
    {
        
        Task AddExpenditure(ExpenditureRequestModel expenditureRequest);
        Task DeleteExpenditure(int id);
        Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel expendituRequest);
        Task<IEnumerable<ExpenditureResponseModel>> GetAllExpendituresByUser(int id);
        Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditures();



    }
}
