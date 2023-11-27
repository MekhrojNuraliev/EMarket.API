using Emarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.DataAccess
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext()
        {
            
        }
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            :base(options)
        { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
