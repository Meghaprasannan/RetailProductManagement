using iStore.VendorData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iStore.API_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        public readonly IVendorData _vendorData;
        public VendorController(IVendorData vendorData)
        {
            _vendorData = vendorData;
        }

        // GET api/<VendorController>/5
        [HttpGet]
        [Route("GetVendorById/{id}")]
        public IActionResult GetVendorById(int id)
        {
            var user = _vendorData.GetVendorDetailsById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"Vendor with id {id} is not found");

        }
        [HttpGet]
        [Route("GetVendorsList")]
        public IActionResult GetVendors()
        {
            return Ok(_vendorData.GetVendors());
        }
        // GET: api/<VendorController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VendorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VendorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VendorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VendorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
