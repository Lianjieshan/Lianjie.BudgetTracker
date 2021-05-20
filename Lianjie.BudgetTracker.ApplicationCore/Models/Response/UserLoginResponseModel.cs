﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lianjie.BudgetTracker.ApplicationCore.Models.Response
{
    public class UserLoginResponseModel
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string? FullName { get; set; }
        public DateTime? JoinedOn { get; set; }
        public string Password { get; set; }

    }
}
