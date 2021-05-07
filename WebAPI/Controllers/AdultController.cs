using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase, IAdultController
    {
        private readonly IFileContextAdapter _fileContextAdapter;

        public AdultController(IFileContextAdapter fileContextAdapter)
        {
            _fileContextAdapter = fileContextAdapter;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAllAdultsAsync()
        {
            try
            {
                IList<Adult> adults = await _fileContextAdapter.GetAllAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdultByIdAsync([FromRoute] int id)
        {
            try
            {
                Adult adult = await _fileContextAdapter.GetAdultByIdAsync(id);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdultAsync([FromBody] Adult adult)
        {
            try
            {
                await _fileContextAdapter.AddAdultAsync(adult);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Adult>> EditAdultAsync([FromBody] Adult adult)
        {
            try
            {
                await _fileContextAdapter.EditAdultAsync(adult);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Adult>> DeleteAdultAsync([FromRoute] int id)
        {
            try
            {
                await _fileContextAdapter.DeleteAdultAsync(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}