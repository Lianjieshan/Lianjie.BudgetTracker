using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Models.Request;
using Lianjie.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lianjie.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IExpenditureService _expendituresService;
        private readonly IIncomeService _incomeService;

        public UserController(IUserService userService, IExpenditureService expenditureService,IIncomeService incomeService)
        {
            _userService = userService;
            _expendituresService = expenditureService;
            _incomeService = incomeService;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("detail/{id:int}")]
        public async Task<ActionResult> GetUserDetailById(int id)
        {
            var user = await _userService.GetUserDetailById(id);
            return Ok(user);
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllUsersasync()
        {
            var user = await _userService.GetAllUsersasync();
            return Ok(user);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

        [HttpPut("updateuser")]
        public async Task<ActionResult> UpdateUser([FromBody] UserRequestModel userRequest)
        {
            await _userService.UpdateUser(userRequest);
            return Ok();
        }





        [HttpPost("addexpenditure")]
        public async Task<ActionResult> CreateExpenditure([FromBody] ExpenditureRequestModel expenditureRequest)
        {
            await _expendituresService.AddExpenditure(expenditureRequest);
            return Ok();
        }

        [HttpDelete("delexpenditure/{id:int}")]
        public async Task<ActionResult> DeleteExpenditure(int id)
        {
            await _expendituresService.DeleteExpenditure(id);
            return Ok();
        }

        [HttpGet("{id:int}/expenditures")]
        public async Task<ActionResult> GetUserExpendituresAsync(int id)
        {
            var userExpenditures = await _expendituresService.GetAllExpendituresByUser(id);
            return Ok(userExpenditures);
        }
        [HttpPut("updateexpenditure")]
        public async Task<ActionResult> UpdateExpenditure([FromBody] ExpenditureRequestModel expenditureRequest)
        {
            await _expendituresService.UpdateExpenditure(expenditureRequest);
            return Ok();
        }

        [HttpGet("expenditures")]
        public async Task<ActionResult> GetAllExpenditureAsync()
        {
            var userExpenditures = await _expendituresService.GetAllExpenditures();
            return Ok(userExpenditures);
        }




        [HttpPost("addincome")]
        public async Task<ActionResult> CreateIncome([FromBody] IncomeRequestModel incomeRequest)
        {
            await _incomeService.AddIncome(incomeRequest);
            return Ok();
        }

        [HttpDelete("delincome/{id:int}")]
        public async Task<ActionResult> DeleteIncome(int id)
        {
            await _incomeService.DeleteIncome(id);
            return Ok();
        }

        [HttpGet("{id:int}/incomes")]
        public async Task<ActionResult> GetUserIncomesAsync(int id)
        {
            var userIncomes = await _incomeService.GetAllIncomesByUser(id);
            return Ok(userIncomes);
        }
        [HttpPut("updateincome")]
        public async Task<ActionResult> UpdateIncome([FromBody] IncomeRequestModel incomeRequest)
        {
            await _incomeService.UpdateIncome(incomeRequest);
            return Ok();
        }

        [HttpGet("incomes")]
        public async Task<ActionResult> GetAllIncomesAsync()
        {
            var userIncomes = await _incomeService.GetAllIncomes();
            return Ok(userIncomes);
        }

    }
}
