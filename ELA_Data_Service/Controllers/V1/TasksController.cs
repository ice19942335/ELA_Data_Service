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
        [HttpGet(ApiRoutes.TasksRoutes.RandomTasks)]
        public async Task<IActionResult> RandomTasks(int? amount)
        {
            if (amount > 10 || amount <= 0)
                return BadRequest("Min amount = 1 | Max amount = 10");
            else if(amount is null)
                return BadRequest("{amount} can't be null");

            var result = await _tasksService.GetRandomTasks((int)amount);

            return Ok(result.TasksList);
        }


        /// <summary>
        /// Return task by taskId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet(ApiRoutes.TasksRoutes.Tasks)]
        public async Task<IActionResult> Tasks(int id)
        {
            if(id == default) 
                return BadRequest("{id} can't be 0 or null");

            var result = await _tasksService.GetTaskById((int)id);

            return Ok(result);
        }
    }
}