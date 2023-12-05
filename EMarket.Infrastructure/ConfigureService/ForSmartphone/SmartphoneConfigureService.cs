using Emarket.Domain.Models;
using EMarket.Application.Services;
using EMarket.Infrastructure.DataAccess;
using EMarket.Infrastructure.MediatR.MediatrForSmartphone;
using EMarket.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.ConfigureService.ForSmartphone
{
    public static class SmartphoneConfigureService
    {
        public static void AddInfrastructureSmartphoneServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISmartphoneService, SmartphoneService>();
            services.AddDbContext<SamsungSmartphoneDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SmartphoneDbContext")));
            services.AddTransient<IRequestHandler<CreateSmartphone, Smartphone>, CreateSmartphoneHandler>();
            services.AddTransient<IRequestHandler<UpdateSmartphone, string>, UpdateSmartphoneHandler>();
            services.AddTransient<IRequestHandler<DeleteSmartphone, string>, DeleteSmartphoneHandler>();
            services.AddTransient<IRequestHandler<GetAllSmartphone, IEnumerable<Smartphone>>, GetAllSmartphoneHandler>();
            services.AddTransient<IRequestHandler<GetByIdSmartphone, Smartphone>, GetByIdSmartphoneHandler>();
        }
    }
}
