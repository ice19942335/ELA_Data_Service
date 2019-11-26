using System.Threading.Tasks;
using ELA_Data_Service.Contracts.V1;
using ELA_Data_Service.Contracts.V1.Responses.Tasks;
using ELA_Data_Service.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ELA_Data_Service.Controllers.V1
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        /// <summary>
        /// Return random tasks by provided amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet(ApiRoutes.Tasks.RandomTasks)]
        public async Task<IActionResult> Index(int amount)
        {
            if (amount > 10 && amount <= 0)
                return BadRequest("(Max 10, Min 1) task per request");

            //var result = await _tasksService.GetRandomTasks(amount);

            //if (!result.Success)
                //return BadRequest(new RandomTasksFailedResponse{ Errors = result.Errors });
                
            return Ok();
        }
    }
}