using Emarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Application.HttpClientBase
{
    public interface IExternalAPIs
    {
        public Task<string> GetAllExternalAPIs();
        public Task<string> GetByIdExternalAPIs(int id);
        public Task<bool> CreateExternalAPIs<T>(T obj);
        public Task<bool> UpdateExternalAPIs<T>(T obj);
        public Task<bool> DeleteExternalAPIs(int id);
    }
}
