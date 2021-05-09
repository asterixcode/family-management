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
    public class JobsController : ControllerBase, IJobsController
    {
        private readonly IJobRepo _jobRepo;

        public JobsController(IJobRepo jobRepo)
        {
            _jobRepo = jobRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Job>>> GetAllJobsAsync()
        {
            try
            {
                IList<Job> jobs = await _jobRepo.GetAllJobsAsync(); 
                return Ok(jobs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}