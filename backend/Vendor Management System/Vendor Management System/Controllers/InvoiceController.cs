using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reactive.Linq;

namespace Vendor_Management_System.Controllers
{
    [Route("api/invoice/")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly Invoice _context;

        public InvoiceController(Invoice context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("invoicelist")]
        public IActionResult GetInvoiceList()
        {
            try
            {
                var i1 = _context.ReadInvoice();
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
                string i1 = _context.CreateInvoice(invoice);
                IObservable<string> message = Observable.Return(i1);
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{invoiceNumber}updateinvoice")]
        public IActionResult PutUpdateInvoiceList([FromBody] Invoice context)
        {
            try
            {
                string i1 = _context.UpdateInvoice(context);
                IObservable<string> message = Observable.Return(i1);
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{invoiceNumber}deleteinvoice")]
        public IActionResult DeleteInvoiceList(string invoiceNumber)
        {
            try
            {
                string i1 = _context.DeleteInvoice(invoiceNumber);
                IObservable<string> message = Observable.Return(i1);
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("invoicebyvendorid")]
        public IActionResult GetInvoiceByVendorId(string code)
        {
            try
            {
                var i = _context.InvoiceByVendorId(code);
                return Ok(i);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }    
        }

        [HttpGet]
        [Route("invoicecountbyvendorid")]
        public IActionResult GetInvoiceCountByVendorCode(string code)
        {
            try
            {
                var i = _context.InvoiceCount(code);
                return Ok(i);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{number}invoicebynumber")]
        public IActionResult GetInvoiceByNumber(string number)
        {
            try
            {
                var v1 = _context.GetInvoiceByNumber(number);
                return Ok(v1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("exporttocsv")]
        public IActionResult ExportToCSV()
        {
            try
            {
                string invoiceData = _context.ExportToCSV();
                return Ok(invoiceData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
