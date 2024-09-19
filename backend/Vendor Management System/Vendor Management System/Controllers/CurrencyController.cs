using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reactive.Linq;

namespace Vendor_Management_System.Controllers
{
    [Route("api/currency/")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly Currency _context;

        public CurrencyController(Currency context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("currencylist")]
        public IActionResult GetCurrencyList()
        {
            try
            {
                var c1 = _context.ReadCurrency();
                return Ok(c1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("createcurrency")]
        public IActionResult PostCreateCurrencyList([FromBody] Currency currency)
        {
            try
            {
                string c1 = _context.CreateCurrency(currency);
                IObservable<string> message = Observable.Return(c1);
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{code}updatecurrency")]
        public IActionResult PutUpdateCurrencyList([FromBody] Currency context)
        {
            try
            {
                string c1 = _context.UpdateCurrency(context);
                IObservable<string> message = Observable.Return(c1);
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{code}currencybycode")]
        public IActionResult GetCurrencyByCode(string code)
        {
            try
            {
                var v1 = _context.GetCurrencyByCode(code);
                return Ok(v1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{code}deletecurrency")]
        public IActionResult DeleteCurrencyList(string code)
        {
            try
            {
                string c1 = _context.DeleteCurrency(code);
                IObservable<string> message = Observable.Return(c1);
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
