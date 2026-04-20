using CleanCarApi.Application.Interfaces;
using CleanCarApi.Domain.Entities;
using CleanCarApi.Domain.Interfaces;
using CleanCarApi.Infrastructure.Data;
using CleanCarApi.Infrastructure.Repositories;
using CleanCarApi.Infrastructure.Services;
using CleanCarApi.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanCarApi.Infrastructure;

// Extension-metod som registrerar allt Infrastructure-lagret behöver
// Anropas från Program.cs med: builder.Services.AddInfrastructure(configuration)
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Registrerar JWT-inställningar som Options så att de kan injiceras typat
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>()!;

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Key))
            };
        });

        services.AddScoped<IRepository<Car>, CarRepository>();
        services.AddScoped<IRepository<Brand>, Repository<Brand>>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
