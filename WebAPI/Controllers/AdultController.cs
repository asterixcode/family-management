using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase, IAdultController
    {
        private readonly IAdultRepo _adultRepo;

        public AdultController(IAdultRepo adultRepo)
        {
            _adultRepo = adultRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAllAdultsAsync()
        {
            try
            {
                IList<Adult> adults = await _adultRepo.GetAllAdultsAsync();
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
                Adult adult = await _adultRepo.GetAdultByIdAsync(id);
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
                await _adultRepo.AddAdultAsync(adult);
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
                await _adultRepo.EditAdultAsync(adult);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdultAsync([FromRoute] int id)
        {
            try
            {
                await _adultRepo.DeleteAdultAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}