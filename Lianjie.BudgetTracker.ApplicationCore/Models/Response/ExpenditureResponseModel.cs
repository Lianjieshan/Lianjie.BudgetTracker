using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lianjie.BudgetTracker.ApplicationCore.Models.Response
{
    public class ExpenditureResponseModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime? ExpDate { get; set; }

        public string Remarks { get; set; }
    }
}
