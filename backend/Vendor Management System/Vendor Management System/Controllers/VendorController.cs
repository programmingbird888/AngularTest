using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reactive.Linq;
using System;

namespace Vendor_Management_System.Controllers
{
    [Route("api/vendor/")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly Vendor _context;
        public VendorController(Vendor context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("vendorlist")]
        public IActionResult GetVendorList()
        {
            try
            {
                var v1 = _context.ReadVendor();
                return Ok(v1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            
        }

        [HttpPost]
        [Route("createvendor")]
        public IActionResult PostCreateVendorList([FromBody] Vendor vendor)
        {
            try
            {
                string v1 = _context.CreateVendor(vendor);
                IObservable<string> message = Observable.Return(v1);
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("{vendorCode}updatevendor")]
        public IActionResult PutUpdateVendorList([FromBody] Vendor context)
        {
            try
            {
                string v1 = _context.UpdateVendor(context);
                IObservable<string> message = Observable.Return(v1);
                return Created("", message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{code}deletevendor")]
        public IActionResult DeleteVendorList(string code)
        {
            try
            {
                string v1 = _context.DeleteVendor(code);
                IObservable<string> message = Observable.Return(v1);
                return Created("", message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("{code}vendorbycode")]
        public IActionResult GetVendorByCode(string code)
        {
            try
            {
                var v1 = _context.GetVendorByCode(code);
                return Ok(v1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ExporttoCSV")]
        public IActionResult ExportToCSV()
        {
            try
            {
                string vendorData = _context.ExportToCSV();
                return Ok(vendorData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}
