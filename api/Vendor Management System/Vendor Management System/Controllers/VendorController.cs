using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reactive.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vendor_Management_System.Models;


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
        [Route("vendor/lambda/{property}/{value}")]
        public async Task<IActionResult> GetLambda(string property, string value)
        {
            if (string.IsNullOrEmpty(property) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Property and value cannot be null or empty.");
            }

            var parameterExpression = Expression.Parameter(typeof(Vendor), "vendor");

            var propertyInfo = typeof(Vendor).GetProperty(property);
            if (propertyInfo == null)
            {
                return BadRequest($"Property '{property}' does not exist on type 'Vendor'.");
            }

            var propertyExpression = Expression.Property(parameterExpression, propertyInfo);

            object convertedValue;
            try
            {
                convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not convert value '{value}' to type '{propertyInfo.PropertyType}': {ex.Message}");
            }

            var constant = Expression.Constant(convertedValue, propertyInfo.PropertyType);
            var equalityExpression = Expression.Equal(propertyExpression, constant);
            var lambda = Expression.Lambda<Func<Vendor, bool>>(equalityExpression, parameterExpression);


            var query = await _context.Vendor.Where(lambda).ToListAsync();

            if (!query.Any())
            {
                return NotFound("No matching vendors found.");
            }

            return Ok(query);
        }


        //[HttpGet]
        //[Route("vendor/lambda/{property}/{value}")]
        //public async Task<IActionResult> GetLambda(string property, string value)
        //{
        //    if (string.IsNullOrEmpty(property) || string.IsNullOrEmpty(value))
        //    {
        //        throw new ArgumentNullException("Property and value cannot be null or empty.");
        //    }

        //    var parameterExpression = Expression.Parameter(typeof(Vendor), "vendor");

        //    var propertyInfo = typeof(Vendor).GetProperty(property);
        //    if (propertyInfo == null)
        //    {
        //        return BadRequest($"Property '{property}' does not exist on type 'Vendor'.");
        //    }

        //    var propertyExpression = Expression.Property(parameterExpression, property);
        //    var constant = Expression.Constant(value);
        //    var equalityExpression = Expression.Equal(propertyExpression, constant);

        //    var lambda = Expression.Lambda<Func<Vendor, bool>>(equalityExpression, parameterExpression);

        //    var query = await _context.Vendor.Where(lambda).ToListAsync();

        //    if (!query.Any())
        //    {
        //        return NotFound("No matching vendors found.");
        //    }

        //    return Ok(query);
        //}

        [HttpGet]
        [Route("vendorlist/{page}/{pageSize}")]
        public async Task<IActionResult> GetVendorList(int page, int pageSize = 5)
        {
            try
            {


                var totalCount = await _context.Vendor.CountAsync();

                var vendors = await _context.Vendor
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return Ok(new
                {
                    Vendors = vendors,
                    TotalCount = totalCount,
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpGet]
        //[Route("vendorlist")]
        //public async Task<IActionResult> GetVendorList()
        //{
        //    try
        //    {
        //        var vendor = await _context.Vendor.ToListAsync();    
        //        return Ok(vendor);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

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
