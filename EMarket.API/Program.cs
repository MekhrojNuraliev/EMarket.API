using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using EMarket.Application;
using EMarket.Application.HttpClientBase;
using EMarket.Application.Services;
using EMarket.Infrastructure;
using EMarket.Infrastructure.ConfigureService.ForSmartphone;
using EMarket.Infrastructure.DataAccess;
using EMarket.Infrastructure.MediatR.MediatrForRole;
using EMarket.Infrastructure.MediatR.MediatrForSmartphone;
using EMarket.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EMarket.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Add services to the container.
            builder.Services.AddCors();

            builder.Services.AddControllers();
            builder.Services.AddScoped<ITokenService, TokenService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructureSmartphoneServices(builder.Configuration);
            builder.Services.AddInfrastructureAuthorizeService(builder.Configuration);
            builder.Services.AddInfrastructureRoleService(builder.Configuration);

            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IExternalAPIs,  ExternalAPIs>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            builder.Services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();

            

            builder.Services.AddDbContext<LoginDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
            });
			builder.Services.AddDbContext<UserDbContext>(options =>
			{
				options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityDbConnection"));
			});
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(config =>
                {
                    config.SaveToken = true;
                    config.TokenValidationParameters = new()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero,
                        ValidateLifetime = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,

                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder => builder
                                  .WithOrigins(app.Configuration["MyCorsURL"])
                                  .WithMethods("GET")
                                  .AllowAnyHeader()
            );
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}