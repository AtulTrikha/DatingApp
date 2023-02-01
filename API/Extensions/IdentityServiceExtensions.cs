
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    //Custom Service created to Add Identity(Authenctication and Authorization) Services in Middlewear
    public static class IdentityServiceExtensions
    {
         public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            //Add Token Service
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                ValidateIssuer = false,
                ValidateAudience = false
                };
            });
            return services;
        }
    }
}