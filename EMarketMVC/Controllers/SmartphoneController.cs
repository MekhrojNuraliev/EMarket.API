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

		//      public async Task<IActionResult> Index()
		//      {
		//	var smartphones = await _service.GetAllAsync();
		//	return View(smartphones);
		//}
		[HttpGet]
		public IActionResult Login()
		{
			return View("~/Views/Smartphone/Index.cshtml");
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
		[HttpGet]
		public async Task<IActionResult> Index(int? page)
		{
			throw new NotImplementedException();
			const int pageSize = 5;
			int pageNumber = page ?? 1;

			var Users = await _service.GetAllAsync();

			var paginatedEmployees =  Paginate(Users, pageNumber, pageSize);

			return View("~/Views/Smartphone/Index.cshtml", paginatedEmployees);
		}

		private PaginationViewModel<Smartphone> Paginate(IEnumerable<Smartphone> items, int pageNumber, int pageSize)
		{
			var paginatedItems = items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			var paginationViewModel = new PaginationViewModel<Smartphone>
			{
				Items = paginatedItems,
				PageNumber = pageNumber,
				PageSize = pageSize,
				TotalItems = items.Count()
			};

			return paginationViewModel;
		}
	}
}
