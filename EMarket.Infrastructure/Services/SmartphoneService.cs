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
            _context.Smartphones.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public bool Update(Smartphone entity)
        {
            _context.Smartphones.Update(entity);
            var executedRows = _context.SaveChanges();
            return executedRows > 0;
        }

        public bool Delete(int Id)
        {
            var item = GetAll().FirstOrDefault(x => x.Id == Id);
            if (item != null)
            {
                _context.Smartphones.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Smartphone> GetAll()
        {
            return _context.Smartphones.ToList();
        }

        public Smartphone GetById(int id)
        {
            var item = GetAll().FirstOrDefault(x => x.Id == id);
            return item;
        }
    }
}
