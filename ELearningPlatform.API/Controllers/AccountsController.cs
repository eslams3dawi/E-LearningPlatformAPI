using ELearningPlatform.BLL.Dtos.AccountDto;
using ELearningPlatform.BLL.Services.AccountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("LoginAsync")]
        public async Task<ActionResult> LoginAsync(LoginDto loginDto)
        {
            var token = await _accountService.LoginAsync(loginDto);

            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }

        [HttpPost("RegisterAsync")]
        public async Task<ActionResult> RegisterAsync(RegisterDto registerDto)
        {
            var token = await _accountService.RegisterAsync(registerDto);

            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
