using Emarket.Domain.Entities;
using EMarket.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForRole
{
    public class UpdateRole : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateRoleHandler : IRequestHandler<UpdateRole, string>
    {
        private readonly IRoleService _service;
        public UpdateRoleHandler(IRoleService roleService)
        {
            _service = roleService;
        }

        public async Task<string> Handle(UpdateRole request, CancellationToken cancellationToken)
        {
            Role role = new Role()
            {
                Id = request.Id,
                Name = request.Name
            };
            var isUpdate = await _service.UpdateAsync(role);
            return isUpdate ? "Role has been updated!" : "Role is not updated!";
        }
    }
}
