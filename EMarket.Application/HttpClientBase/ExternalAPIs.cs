using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using Emarket.Domain.Models;

namespace EMarket.Application.HttpClientBase
{
    public class ExternalAPIs : IExternalAPIs
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;
        public ExternalAPIs(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
            _baseUri = configuration.GetSection("ExternalAPIs")["MekhrojsAPIs"];
        }
        public async Task<bool> CreateExternalAPIs<T>(T obj)
        {
            var response = await _client.PostAsJsonAsync($"{_baseUri}/Home/Create", obj);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> UpdateExternalAPIs<T>(T obj)
        {
            var response = await _client.PutAsJsonAsync($"{_baseUri}/Home/Update", obj);
            if (response.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> DeleteExternalAPIs(int id)
        {
            var response = await _client.DeleteAsync($"{_baseUri}/Home/Delete?id={id}");
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<string> GetAllExternalAPIs()
        {
            var response = await _client.GetAsync($"{_baseUri}/Home/GetAll");
            var result = await response.Content.ReadAsStringAsync();
            await Console.Out.WriteLineAsync(result);
            return result;
        }

        public async Task<string> GetByIdExternalAPIs(int id)
        {
            var response = await _client.GetAsync($"{_baseUri}/Home/GetById?id={id}");
            var res = await response.Content.ReadAsStringAsync();
            return res;
        }
    }
}
