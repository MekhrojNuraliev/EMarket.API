using Emarket.Domain.Entities;
using EMarket.Application.Services;
using EMarket.Infrastructure.MediatR.MediatrForAuth;
using EMarket.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.ConfigureService.ForSmartphone
{
    public static class AuthConfigureService
    {
        public static void AddInfrastructureAuthorizeService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddTransient<IRequestHandler<RegisterUser, User>, RegisterUserHandler>();
        }
    }
}
