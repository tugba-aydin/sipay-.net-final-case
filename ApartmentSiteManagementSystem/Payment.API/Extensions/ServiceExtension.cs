using Microsoft.EntityFrameworkCore;
using Payment.API.Data;
using Payment.API.Repository;
using Payment.API.Services.Abstract;
using Payment.API.Services.Concrete;
using System.Text;

namespace Payment.API.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<ApplicationPaymentDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
        }

        //Implementation of all services was done with DI
        public static void ServiceManager(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IPaymentService,PaymentService>();
        }
    }
}
