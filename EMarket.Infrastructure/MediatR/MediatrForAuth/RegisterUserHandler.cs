using Emarket.Domain.Entities;
using EMarket.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.MediatR.MediatrForAuth
{
    public class RegisterUser : IRequest<User>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

    }
    public class RegisterUserHandler : IRequestHandler<RegisterUser, User>
    {
        private readonly IIdentityService _service;
        public RegisterUserHandler(IIdentityService service) => _service = service;
        

        public async Task<User> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                Name = request.Name,
                UserName = request.UserName,
                Password = request.Password,
                Phone = request.Phone,
                //Roles = new List<Role>()
                //{
                //    new Role()
                //    {
                //        Id = 2
                //    }
                //}       
            };
            await _service.RegisterAsync(user);
            return user;
        }
    }
}
