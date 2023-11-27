using Emarket.Domain.Entities;
using EMarket.Application.Services;
using Emarket.Domain.Models;
using EMarket.Infrastructure.MediatR.MediatrForSmartphone;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForRole
{
    public class CreateRole : IRequest<Role>
    {
        public string Name { get; set; }
    }
    public class CreateRoleHandler : IRequestHandler<CreateRole, Role>
    {
        private readonly IRoleService _roleService;

        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Role> Handle(CreateRole request, CancellationToken cancellationToken)
        {

            Role role = new Role()
            {
                Name = request.Name,
                Users = new List<User>(),
                Permissions = new List<Permission>()
            };
            await _roleService.CreateAsync(role);
            return role;
        }
    }
}
