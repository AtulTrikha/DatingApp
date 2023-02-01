using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//1. Add Controller Service
builder.Services.AddControllers();

//2. Add Custom Services using Extension 
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


//Build 
var app = builder.Build();

//Add CORS Middlewear
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//Add Authentication Middlewear
app.UseAuthentication();

//Add Authorization Middlewear
app.UseAuthorization();
app.MapControllers();
app.Run();
