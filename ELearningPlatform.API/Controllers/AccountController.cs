using ELearningPlatform.BLL.Dtos.AccountDto;
using ELearningPlatform.BLL.Services.AccountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) //Inject the IConfiguration to access to appsettings
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var token = await _accountService.Login(loginDto);

            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var token = await _accountService.Register(registerDto);

            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
