using Demo.Prova.Core.Entities;
using Demo.Prova.Core.IServices;
using Demo.Prova.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Prova.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoedasController : ControllerBase
    {
        private IBaseService<Moedas> _baseMoedaService;

        public MoedasController(IBaseService<Moedas> baseMoedaService)
        {
            _baseMoedaService = baseMoedaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<UserValidator>(user).Id);
        }

        [HttpGet]
        public IActionResult GetItemFila()
        {
            return Execute(() => _baseMoedaService. Get<MoedasModel>());
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
