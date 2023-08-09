using BLL.Models;
using BLL.Services.Abstract;
using BLL.Services.Concrete;
using DAL.Context;
using DAL.Entities;
using DAL.Repository;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApartmentManagement.API.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
        }

        public static void ConfigureHangfire(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHangfire(x =>
            {
                x.UsePostgreSqlStorage(configuration.GetConnectionString("PostgreSql"));
            });
            services.AddHangfireServer();
        }

        public static void ConfigureIdentity(this IServiceCollection services){
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureAuthentication(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
        }

        public static void ConfigureMail(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettingsModel>(configuration.GetSection("MailSettings"));
        }
        //Implementation of all services was done with DI
        public static void ServiceManagers(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPaymentService,PaymentService>();
        }
    }
}
