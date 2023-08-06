using BLL.Services.Abstract;
using BLL.Services.Concrete;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApartmentManagement.API.Extensions
{
    public static class ServicesExtensions
    {
        //Configured to connect to database
        //public static void ConfigureSqlContext(this IServiceCollection services,
        //    IConfiguration configuration) => services.AddDbContext<ApplicationContext>(options =>
        //            options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));

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

            //services.AddScoped<UserManager<User>, UserManager<User>>();
            //services.AddScoped<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();

        }
    }
}
