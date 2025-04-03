using ELearningPlatform.BLL.Services.AccountService;
using ELearningPlatform.BLL.Services.StudentService;
using ELearningPlatform.DAL.Database;
using ELearningPlatform.DAL.Models;
using ELearningPlatform.DAL.Repository.CourseRepository;
using ELearningPlatform.DAL.Repository.GenericRepository;
using ELearningPlatform.DAL.Repository.InstructorRepository;
using ELearningPlatform.DAL.Repository.StudentRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ELearningPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add DbContext with SQL Server
            builder.Services.AddDbContext<ELearningContext>(options =>
                options.UseSqlServer
                (builder.Configuration.GetConnectionString
                ("Server = ESLAMS3DAWY; Database = ELearningPlatform; Integrated Security = True; Trust Server Certificate = True")));
            
            // Register Identity with DbContext
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<ELearningContext>();

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();



            //------------//
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "eslam";
                //Checks if the token is valid

                option.DefaultChallengeScheme = "eslam";
                //the action if the token is invalid 

            }).AddJwtBearer("eslam", options =>
            {
                //Get the secret key to be able to generate another signature to be compared
                var securitykeystring = builder.Configuration.GetSection("SecretKey").Value;
                var securtykeyByte = Encoding.ASCII.GetBytes(securitykeystring);
                SecurityKey securityKey = new SymmetricSecurityKey(securtykeyByte);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = securityKey,

                  //Identity the front URL that will use that API, to be more secure 
                    //ValidAudience = "url" ,
                    //ValidIssuer = "url",

                  //false if there is no specific front URL
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //------------//
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
