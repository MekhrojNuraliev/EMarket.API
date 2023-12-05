using Emarket.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.DataAccess
{
	public class UserDbContext : IdentityDbContext<User, IdentityRole<int>, int>
	{
        public UserDbContext(DbContextOptions<UserDbContext> options)
            :base(options)
        {
            
        }
    }
}
