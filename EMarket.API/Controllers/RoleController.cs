using Emarket.Domain.Models;
using EMarket.Application.Services;
using EMarket.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Emarket.Domain.Entities;
using MediatR;
using EMarket.Infrastructure.MediatR.MediatrForRole;

namespace EMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleController : Controller
    {

        private readonly IRoleService _roleService;
        private readonly IMediator _mediator;

        public RoleController(IRoleService roleService, IMediator mediator)
        {
            _roleService = roleService;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<Response<Role>> Create(CreateRole role)
        {
            var result = await _mediator.Send(role);
            return new(result);
        }
        [HttpPut]
        public async Task<Response<Role>> Update(Role role)
        {
            await _roleService.UpdateAsync(role);
            return new(role);
        }
        [HttpDelete]
        public async Task<Response<string>> Delete(int id)
        {
            await _roleService.DeleteAsync(id);
            return new("Success");
        }
        [HttpGet]
        public async Task<IEnumerable<Role>> GetAll()
        {
            return _roleService.GetAllAsync().Result;
        }
        [HttpGet]
        public async Task<Role> GetById(int id)
        {
            return _roleService.GetByIdAsync(id).Result;
        }
    }
}
