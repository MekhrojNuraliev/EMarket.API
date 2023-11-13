using EMarket.Application.Services;
using EMarket.Infrastructure.DataAccess;
using EMarket.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure
{
    public static class ConfigureServices
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISmartphoneService, SmartphoneService>();
            services.AddDbContext<SamsungSmartphoneDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SamsungSmartphoneDbContext")));
        }
    }
}
