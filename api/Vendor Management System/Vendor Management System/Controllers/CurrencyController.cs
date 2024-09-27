using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reactive.Linq;
using Vendor_Management_System.Models;

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
        [Route("currencylist/{page}/{pageSize}")]
        public async Task<IActionResult> GetCurrencyList(int page, int pageSize = 5)
        {
            try
            {
                var totalCurrencyCount = await _context.Currency.CountAsync();

                var currency = await _context.Currency
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                if (page > currency.Count)
                {
                    return NotFound("Page out of range.");
                }
                return Ok(new
                {
                    Currency = currency,
                    TotalCount = totalCurrencyCount,
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling((double)totalCurrencyCount / pageSize)
                });
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
                currency.CurrencyCode.ToUpper();
                await _context.Currency.AddAsync(currency); 
                await _context.SaveChangesAsync();
                return Created("", new {m = "Added!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updatecurrency/{id}")]
        public async Task<IActionResult> PutUpdateCurrencyList([FromBody] Currency currency, int id)
        {
            try
            {
                if (!await _context.Currency.AnyAsync(c => c.CurrencyId == id) && (currency.CurrencyId != id))
                {
                    return NotFound("Currency not found.");
                }
                _context.Currency.Update(currency);
                await _context.SaveChangesAsync();
                return Created("", new { m = "Edited." }); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletecurrency/{id}")]
        public async Task<IActionResult> DeleteCurrencyList(int id)
        {
            try
            {
                var currency = await _context.Currency.SingleOrDefaultAsync(c => c.CurrencyId == id);
                if (currency == null)
                {
                    return NotFound("Currency not found.");
                }

                _context.Currency.Remove(currency);
                await _context.SaveChangesAsync();
                return Created("", new { m = "Deleted." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("currencybyid/{id}")]
        public async Task<IActionResult> GetCurrencyById(int id)
        {
            try
            {
                var currency = await _context.Currency.SingleOrDefaultAsync(c => c.CurrencyId == id);
                if (currency == null)
                {
                    return NotFound("Currency not present.");
                }
                return Ok(currency);
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
