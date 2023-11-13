using Emarket.Domain.Models;
using EMarket.Application.HttpClientBase;
using EMarket.Application.MediatR;
using EMarket.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SmartphoneController : ControllerBase
    {
        private readonly ISmartphoneService _smartphoneService;
        private readonly IExternalAPIs _externalAPIs;
        private readonly IMediator _mediator;
        public SmartphoneController(ISmartphoneService smartphoneService, IExternalAPIs externalAPIs, IMediator mediator)
        {
            _externalAPIs = externalAPIs;
            _smartphoneService = smartphoneService;
        }
        [HttpPost]
        public async Task<ResponseModel<Smartphone>> Create(Smartphone _smartphone)
        {
            var request = new SmartphoneCreate() { smartphone = _smartphone };
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpPut]
        public string Update(Smartphone pharm)
        {
            _smartphoneService.Update(pharm);
            return "Success!";
        }
        [HttpDelete]
        public string Delete(int id)
        {
            _smartphoneService.Delete(id);
            return "Success!";
        }
        [HttpGet]
        public IEnumerable<Smartphone> GetAll()
        {
            return _smartphoneService.GetAll();
        }
        [HttpGet]
        public Smartphone GetById(int id)
        {
            return _smartphoneService.GetById(id);
        }
        #region HttpClient
        //[HttpDelete]
        //public async Task<IActionResult> DeleteHttp(int id)
        //{
        //    var res = await _externalAPIs.DeleteExternalAPIs(id);
        //    return Ok(res);
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetAllHttp()
        //{
        //    var response = await _externalAPIs.GetAllExternalAPIs();
        //    return Ok(response);
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetByIdHttp(int id)
        //{
        //    var res = await _externalAPIs.GetByIdExternalAPIs(id);
        //    return Ok(res);
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateHttp(Smartphone smartphone)
        //{
        //    var res = _externalAPIs.CreateExternalAPIs<Smartphone>(smartphone);
        //    return Ok(res);
        //}
        //[HttpPut]
        //public async Task<IActionResult> UpdateHttp(Smartphone smartphone)
        //{
        //    var res = _externalAPIs.UpdateExternalAPIs<Smartphone>(smartphone);
        //    return Ok(res);
        //}
        #endregion
        #region
        //[HttpGet]
        //public Smartphone EngKop()
        //{
        //    var list = _smartphoneService.GetAll().ToList();
        //    var result = list.Max(x => x.Count);
        //    var res = list.FirstOrDefault(x => x.Count == result);
        //    return res;
        //}
        //[HttpGet]
        //public IEnumerable<Smartphone> EngKam5ta()
        //{
        //    var list = _smartphoneService.GetAll().ToList();
        //    var result = list.OrderByDescending(x => x.Count).Take(5);
        //    return result;
        //}
        //[HttpPatch]
        //public IActionResult Search(string search)
        //{
        //    var result = _smartphoneService.GetAll().ToList().Where(x => x.Model == search);
                                                    
        //    if (result != null)
        //        return Ok(result);
        //    return NotFound();
        //}
#endregion
    }
}
