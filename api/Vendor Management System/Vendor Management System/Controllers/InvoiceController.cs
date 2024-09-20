using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("invoicelist")]
        public IActionResult GetInvoiceList()
        {
            try
            {
                var i1 = _context.Invoice;
                return Ok(i1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("createinvoice")]
        public IActionResult PostCreateInvoiceList([FromBody] Invoice invoice)
        {
            try
            {
                _context.Invoice.Add(invoice);
                _context.SaveChanges();
                IObservable<string> message = Observable.Return("Added!");
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut]
        [Route("updateinvoice")]
        public IActionResult PutUpdateInvoiceList([FromBody] Invoice context)
        {
            try
            {
                var invoice = new Invoice { 
                    InvoiceId = context.InvoiceId, 
                    InvoiceNumber = context.InvoiceNumber, 
                    InvoiceCurrencyId = context.InvoiceCurrencyId, 
                    VendorId = context.VendorId,
                    InvoiceAmount = context.InvoiceAmount,
                    InvoiceReceivedDate = context.InvoiceReceivedDate,
                    InvoiceDueDate = context.InvoiceDueDate,
                    IsActive = context.IsActive
                };
                _context.Invoice.Update(invoice);
                _context.SaveChanges();
                IObservable<string> message = Observable.Return("Updated!");
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete]
        [Route("{invoiceNumber}deleteinvoice")]
        public IActionResult DeleteInvoiceList(Int64 invoiceNumber)
        {
            try
            {
                var invoice = _context.Invoice.SingleOrDefault(inv => inv.InvoiceNumber == invoiceNumber);
                if (invoice == null)
                {
                    return NotFound("Invoices not found.");
                }

                _context.Invoice.Remove(invoice);
                _context.SaveChanges();
                IObservable<string> message = Observable.Return("Removed!");
                return Created("", message);
            }
            catch (Exception ex)
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
