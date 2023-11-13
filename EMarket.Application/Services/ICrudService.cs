using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Application.Services
{
    public interface ICrudService<T>
    {
        Task<T> CreateAsync(T entity);
        bool Update(T entity);
        bool Delete(int Id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
