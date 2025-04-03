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

            //Register the context
            builder.Services.AddDbContext<ELearningContext>(options =>
                options.UseSqlServer
                (builder.Configuration.GetConnectionString
                ("Server = ESLAMS3DAWY; Database = ELearningPlatform; Integrated Security = True; Trust Server Certificate = True")));


            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ELearningContext>();

            //------------//
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "eslam";
                option.DefaultChallengeScheme = "eslam";
            }).AddJwtBearer("eslam", options =>
            {
                var securitykeystring = builder.Configuration.GetSection("SecretKey").Value;
                var securtykeyByte = Encoding.ASCII.GetBytes(securitykeystring);
                SecurityKey securityKey = new SymmetricSecurityKey(securtykeyByte);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = securityKey,
                    //ValidAudience = "url" ,
                    //ValidIssuer = "url",
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
