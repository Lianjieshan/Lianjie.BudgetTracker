using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lianjie.BudgetTracker.ApplicationCore.Models.Request;
using Lianjie.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lianjie.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> RegisterUserAsync( UserRegisterRequestModel user)
        {
            var createdUser = await _userService.RegisterUser(user);
            return Ok();
            
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginAsync(UserLoginRequestModel loginRequest)
        {
            var user = await _userService.ValidateUser(loginRequest.Email, loginRequest.Password);
            if (user == null) return Unauthorized();

            return Ok();
        }
    }
}
