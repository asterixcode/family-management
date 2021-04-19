using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace WebAPI.Controllers
{
    public interface IAdultController
    {
        Task<ActionResult<IList<Adult>>> GetAllAdultsAsync();
        Task<ActionResult<Adult>> GetAdultByIdAsync(int id);
        Task<ActionResult<Adult>> AddAdultAsync(Adult adult);
        Task<ActionResult<Adult>> EditAdultAsync(Adult adult);
        Task<ActionResult<Adult>> DeleteAdultAsync(int id);

    }
}