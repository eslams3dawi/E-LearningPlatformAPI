using ELearningPlatform.BLL.Dtos.AccountDto;
using ELearningPlatform.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ELearningPlatform.BLL.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Name);
            if (user == null)
                return null;

            var CheckPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!CheckPassword)/////
                return null;

            var claims = await _userManager.GetClaimsAsync(user);
            return GenerateToken(claims);
        }

        public async Task<string> Register(RegisterDto registerDto)
        {
            //Mapping .. RegisterDto → User
            ApplicationUser user = new ApplicationUser();

            user.Email = registerDto.Email;
            user.UserName = registerDto.Name;

            var result = await _userManager.CreateAsync(user, registerDto.Password);//Hash the password, through passing the user & password

            if (result.Succeeded)
            {
                //Generate The Token
                //1. Create Claims
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("Role", "Admin"));
                claims.Add(new Claim("Name", registerDto.Name));

                //Store the claims on database when registration, because the user will want them when login
                await _userManager.AddClaimsAsync(user, claims);

                return GenerateToken(claims);
            }
            //Else
            return null;
        }

        private string GenerateToken(IList<Claim> claims)
        {
            //2. Create SigningCredentials(securityKey, SecurityAlgorithms.Sha256)
            //1. Install IdentityModel.Tokens & IdentityModel.Tokens.jwt Package

            //2. Take the secrete key as string & convert it to byte array
            var securityKeyString = _configuration.GetSection("SecretKey").Value;
            var securityKeyBytes = Encoding.ASCII.GetBytes(securityKeyString);

            //3. Identify key type → Symmetric Security Key: Takes the secret key as byte array
            SecurityKey securityKey = new SymmetricSecurityKey(securityKeyBytes);

            //4. Generate the signingCredentials → Identify the secrete key & hashing algorithm
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            //3. Identify the expiry date
            var expire = DateTime.UtcNow.AddDays(7); //The Token will be expired after one week
                                                     //Add all above parts to the token
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: signingCredentials);

            //Convert SecurityToken type into string
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
