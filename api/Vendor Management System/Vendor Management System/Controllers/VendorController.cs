using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reactive.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace Vendor_Management_System.Controllers
{
    [Route("api/vendor/")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public VendorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("vendorlist")]
        public async Task<IActionResult> GetVendorList()
        {
            try
            {
                var v1 = await _context.Vendor.ToListAsync(); 
                return Ok(v1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("createvendor")]
        public async Task<IActionResult> PostCreateVendorList([FromBody] Vendor vendor)
        {
            try
            {
                await _context.Vendor.AddAsync(vendor); 
                await _context.SaveChangesAsync(); 
                return Created("", new { msg = "Added" }); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("updatevendor/{id}")]
        public async Task<IActionResult> PutUpdateVendorList([FromBody] Vendor vendor, int id)
        {
            try
            {
                if(!await _context.Vendor.AnyAsync(v => v.VendorId == id) && (vendor.VendorId != id))
                {
                    return NotFound("Vendor not found.");
                }
                _context.Vendor.Update(vendor);
                await _context.SaveChangesAsync(); 
                return Created("",new {m =  "Updated!" } ); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletevendor/{id}")]
        public async Task<IActionResult> DeleteVendorList(int id)
        {
            try
            {
                var vendor = await _context.Vendor.SingleOrDefaultAsync(v => v.VendorId == id); 
                if (vendor == null)
                {
                    return BadRequest("Vendor not found.");
                }

                if (await _context.Invoice.AnyAsync(chk => chk.VendorId == vendor.VendorId)) 
                {
                    return BadRequest("Invoice is present! Delete Invoice first!");
                }

                _context.Vendor.Remove(vendor);
                await _context.SaveChangesAsync();
                return Created("", new { m = "Deleted!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVendorById(int id)
        {
            try
            {
                var vendor = await _context.Vendor.SingleOrDefaultAsync(v => v.VendorId == id);
                if (vendor == null)
                {
                    return NotFound("Vendor not present.");
                }
                return Ok(vendor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("ExporttoCSV")]
        //public IActionResult ExportToCSV()
        //{
        //    try
        //    {
        //        string vendorData = _context.ExportToCSV();
        //        return Ok(vendorData);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }

        //}
    }
}
