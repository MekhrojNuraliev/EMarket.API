using EMarket.Application.Services;
using Emarket.Domain.Entities;
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
using EMarket.Infrastructure.MediatR.MediatrForRole;

namespace EMarket.Infrastructure.ConfigureService.ForSmartphone
{
    public static class RoleConfigureService
    {
        public static void AddInfrastructureRoleService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddTransient<IRequestHandler<CreateRole, Role>, CreateRoleHandler>();
            services.AddTransient<IRequestHandler<UpdateRole, string>, UpdateRoleHandler>();
            services.AddTransient<IRequestHandler<DeleteRole, string>, DeleteRoleHandler>();
            services.AddTransient<IRequestHandler<GetAllRole, IEnumerable<Role>>, GetAllRoleHandler>();
            services.AddTransient<IRequestHandler<GetByIdRole, Role>, GetByIdRoleHandler>();
        }
    }
}
