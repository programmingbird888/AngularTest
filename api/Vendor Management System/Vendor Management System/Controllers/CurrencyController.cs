using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Linq;

namespace Vendor_Management_System.Controllers
{
    [Route("api/currency/")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CurrencyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("currencylist")]
        public async Task<IActionResult> GetCurrencyList()
        {
            try
            {
                var c1 = await _context.Currency.ToListAsync();
                return Ok(c1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("createcurrency")]
        public async Task<IActionResult> PostCreateCurrencyList([FromBody] Currency currency)
        {
            try
            {
                await _context.Currency.AddAsync(currency); 
                await _context.SaveChangesAsync();
                return Created("", "Added!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updatecurrency")]
        public async Task<IActionResult> PutUpdateCurrencyList([FromBody] Currency context)
        {
            try
            {
                var currency = new Currency
                {
                    CurrencyId = context.CurrencyId,
                    CurrencyName = context.CurrencyName,
                    CurrencyCode = context.CurrencyCode
                };

                _context.Currency.Update(currency);
                await _context.SaveChangesAsync(); 

                return Ok("Updated!"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{code}deletecurrency")]
        public async Task<IActionResult> DeleteCurrencyList(string code)
        {
            try
            {
                var currency = await _context.Currency.SingleOrDefaultAsync(c => c.CurrencyCode == code);
                if (currency == null)
                {
                    return NotFound("Currency not found.");
                }

                _context.Currency.Remove(currency);
                await _context.SaveChangesAsync();

                return Ok("Removed!"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpGet]
        //[Route("{code}currencybycode")]
        //public IActionResult GetCurrencyByCode(string code)
        //{
        //    try
        //    {
        //        var v1 = _context.GetCurrencyByCode(code);
        //        return Ok(v1);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
