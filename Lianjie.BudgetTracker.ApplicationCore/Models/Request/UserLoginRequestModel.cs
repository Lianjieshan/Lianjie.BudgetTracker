﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lianjie.BudgetTracker.ApplicationCore.Models.Request
{
    public class UserLoginRequestModel
    {
        
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
