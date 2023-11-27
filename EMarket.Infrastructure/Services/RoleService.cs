using Emarket.Domain.Entities;
using EMarket.Application.Services;
using EMarket.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly IdentityDbContext _dbContext;

        public RoleService(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> CreateAsync(Role entity)
        {
            await _dbContext.Roles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var item = GetAllAsync().Result.FirstOrDefault(x => x.Id == Id);
            if (item != null)
            {
                _dbContext.Roles.Remove(item);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var res = _dbContext.Roles.ToList();
            return res;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            var item = GetAllAsync().Result.FirstOrDefault(x => x.Id == id);
            return item;
        }

        public async Task<bool> UpdateAsync(Role entity)
        {
            _dbContext.Roles.Update(entity);
            var executedRows = await _dbContext.SaveChangesAsync();
            return executedRows > 0;
        }
    }
}
