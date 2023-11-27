using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.DataAccess
{
    public class SamsungSmartphoneDbContext : DbContext
    {
        public SamsungSmartphoneDbContext()
        {
            
        }
        public SamsungSmartphoneDbContext(DbContextOptions<SamsungSmartphoneDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Smartphone> Smartphones { get; set; }
    }
}
