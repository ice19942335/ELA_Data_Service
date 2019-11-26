using ELA_Data_Service.Contracts.V1;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ELA_Data_Service.Controllers.V1
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class TasksController : Controller
    {
        [HttpGet(ApiRoutes.Tasks.RandomTasks)]
        public IActionResult Index()
        {
            return View();
        }
    }
}