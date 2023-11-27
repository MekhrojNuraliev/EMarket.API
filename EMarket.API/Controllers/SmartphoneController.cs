using Emarket.Domain.Entities;
using Emarket.Domain.Models;
using EMarket.Application.HttpClientBase;
using EMarket.Application.Services;
using EMarket.Infrastructure.MediatR.MediatrForSmartphone;
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
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<Response<Smartphone>> Create(CreateSmartphone smartphone)
        {
            var result = await _mediator.Send(smartphone);
            return new(result);
        }
        [HttpPut]
        public async Task<ActionResult<string>> Update(UpdateSmartphone smartphone)
        {
            var res = await _mediator.Send(smartphone);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<ActionResult<string>> Delete(DeleteSmartphone phone)
        {
            var res = await _mediator.Send(phone);
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<Smartphone>> GetAll(GetAllSmartphone phone)
        {
            var res = await _mediator.Send(phone);
            return Ok(res);
        }
        [HttpGet]
        public async Task<Smartphone> GetById(int id)
        {
            return _smartphoneService.GetByIdAsync(id).Result;
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
