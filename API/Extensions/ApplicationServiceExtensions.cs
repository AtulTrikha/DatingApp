using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    //Custom Service created to Add Application Services in Middlewear
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //Add Entity Framework Service using Sqllite
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            //Add CORS Services
            services.AddCors();

            //Add Token Service
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}