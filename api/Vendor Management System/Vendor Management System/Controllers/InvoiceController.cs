using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reactive.Linq;

namespace Vendor_Management_System.Controllers
{
    [Route("api/invoice/")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("invoicelist/{currencyId}/{vendorId}")]
        public async Task<IActionResult> GetInvoiceList(int currencyId, int vendorId)
        {
            try
            {
                var invoice = _context.Invoice.Where(i => i.VendorId == (vendorId == 0 ? i.VendorId : vendorId) && i.InvoiceCurrencyId == (currencyId == 0 ? i.InvoiceCurrencyId : currencyId)).ToList();
                
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("createinvoice")]
        public async Task<IActionResult> PostCreateInvoiceList([FromBody] Invoice invoice)
        {
            try
            {
                await _context.Invoice.AddAsync(invoice);
                await _context.SaveChangesAsync();
                return Created("", new { m = "Added." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut]
        [Route("updateinvoice/{id}")]
        public async Task<IActionResult> PutUpdateInvoiceList([FromBody] Invoice invoice, int id)
        {
            try
            {
                if (!await _context.Invoice.AnyAsync(i => i.InvoiceId == id) && (invoice.InvoiceId != id))
                {
                    return NotFound("Invocie not found.");
                }
                _context.Invoice.Update(invoice);
                await _context.SaveChangesAsync();
                return Created("", new {m = "Edited."});
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete]
        [Route("deleteinvoice/{id}")]
        public async Task<IActionResult> DeleteInvoiceList(int id)
        {
            try
            {
                var invoice = await _context.Invoice.SingleOrDefaultAsync(inv => inv.InvoiceId == id);
                if (invoice == null)
                {
                    return BadRequest("Invoice not found.");
                }

                _context.Invoice.Remove(invoice);
                await _context.SaveChangesAsync();
                return Created("", new { m = "Deleted." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("invoicebyid/{id}")]
        public async Task<IActionResult> GetInvoiceDetails(int id)
        {
            try
            {
                var invoice = _context.Invoice.SingleOrDefault(i => i.InvoiceId == id);
                if(invoice == null)
                {
                    return NotFound("Invoice not present.");
                }
                return Ok(invoice);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //[HttpGet]
        //[Route("invoicebyvendorid")]
        //public IActionResult GetInvoiceByVendorId(string code)
        //{
        //    try
        //    {
        //        var i = _context.InvoiceByVendorId(code);
        //        return Ok(i);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }    
        //}

        //[HttpGet]
        //[Route("invoicecountbyvendorid")]
        //public IActionResult GetInvoiceCountByVendorCode(string code)
        //{
        //    try
        //    {
        //        var i = _context.InvoiceCount(code);
        //        return Ok(i);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("{number}invoicebynumber")]
        //public IActionResult GetInvoiceByNumber(string number)
        //{
        //    try
        //    {
        //        var v1 = _context.GetInvoiceByNumber(number);
        //        return Ok(v1);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("exporttocsv")]
        //public IActionResult ExportToCSV()
        //{
        //    try
        //    {
        //        string invoiceData = _context.ExportToCSV();
        //        return Ok(invoiceData);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
    }
}
