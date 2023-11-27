using Emarket.Domain.Models;
using EMarket.Application.Services;
using EMarket.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.Services
{
    public class SmartphoneService : ISmartphoneService
    {
        private readonly SamsungSmartphoneDbContext _context;
        public SmartphoneService(SamsungSmartphoneDbContext context)
        {
            _context = context;
        }
        public async Task<Smartphone> CreateAsync(Smartphone entity)
        {
          await  _context.Smartphones.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> UpdateAsync(Smartphone entity)
        {
            _context.Smartphones.Update(entity);
            var executedRows = await _context.SaveChangesAsync();
            return executedRows > 0;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var item = GetAllAsync().Result.FirstOrDefault(x => x.Id == Id);
            if (item != null)
            {
                _context.Smartphones.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Smartphone>> GetAllAsync()
        {
            return _context.Smartphones.OrderBy(x => x.Id).ToList();
        }

        public async Task<Smartphone> GetByIdAsync(int id)
        {
            var item = GetAllAsync().Result.FirstOrDefault(x => x.Id == id);
            return item;
        }
    }
}
