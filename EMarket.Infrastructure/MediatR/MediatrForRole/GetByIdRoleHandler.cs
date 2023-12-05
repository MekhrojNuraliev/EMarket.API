using Emarket.Domain.Entities;
using EMarket.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForRole
{
    public class GetByIdRole : IRequest<Role>
    {
        public int Id { get; set; }
    }
    public class GetByIdRoleHandler : IRequestHandler<GetByIdRole, Role>
    {
        private readonly IRoleService _service;

        public GetByIdRoleHandler(IRoleService service) => _service = service;
        public async Task<Role> Handle(GetByIdRole request, CancellationToken cancellationToken)
        {
            var role = await _service.GetByIdAsync(request.Id);
            return role;
        }
    }
}
