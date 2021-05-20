using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Entities;

namespace Lianjie.BudgetTracker.ApplicationCore.Models.Response
{
    public class UserDetailResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public decimal TotalIncomes { get; set; }
        public decimal TotalExpenditures { get; set; }
        public List<IncomeResponseModel> Incomes { get; set; }
        public List<ExpenditureResponseModel> Expenditures { get; set; }
    }
}
