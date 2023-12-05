using Emarket.Domain.Models;
using EMarket.Application.Services;
using EMarketMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMarketMVC.Controllers
{
    public class SmartphoneController : Controller
    {
        private readonly ISmartphoneService _service;

        public SmartphoneController(ISmartphoneService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
			var smartphones = await _service.GetAllAsync();
			return View(smartphones);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromForm]Smartphone smartphone)
		{
            var res = await _service.CreateAsync(smartphone);
			return View(res);
		}
        [HttpPost]
		public async Task<IActionResult> Update([FromForm] Smartphone smartphone)
		{
			var res = await _service.UpdateAsync(smartphone);
			return View(res);
		}
		[HttpPost]
		public async Task<IActionResult> Delete([FromForm] Smartphone smartphone)
		{
			var res = await _service.DeleteAsync(smartphone.Id);
			return View(res);
		}
	}
}
