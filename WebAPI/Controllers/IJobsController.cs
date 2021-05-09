using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public interface IJobsController
    {
        Task<ActionResult<IList<Job>>> GetAllJobsAsync();
    }
}