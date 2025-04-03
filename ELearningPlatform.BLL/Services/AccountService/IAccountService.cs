using ELearningPlatform.BLL.Dtos.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.AccountService
{
    public interface IAccountService
    {
        Task<string> Login(LoginDto loginDto);
        Task<string> Register(RegisterDto registerDto);
    }
}
