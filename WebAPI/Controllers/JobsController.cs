using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IFileContextAdapter _fileContextAdapter;

        public JobsController(IFileContextAdapter fileContextAdapter)
        {
            _fileContextAdapter = fileContextAdapter;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Job>>> GetAllJobsAsync()
        {
            try
            {
                IList<Job> jobs = await _fileContextAdapter.GetAllJobsAsync();
                foreach (var job in jobs)
                {
                    Console.WriteLine(job.JobTitle);
                }
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