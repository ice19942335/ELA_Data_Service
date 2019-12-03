using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service.Contracts.V1;
using ELA_Data_Service.Contracts.V1.Requests.Users;
using ELA_Data_Service.Contracts.V1.Responses.Users;
using ELA_Data_Service.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ELA_Data_Service.Controllers.V1
{
    [EnableCors]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Updating user points
        /// </summary>
        /// <returns></returns>
        [HttpPut(ApiRoutes.UsersRoutes.UserPoints)]
        public async Task<IActionResult> Points([FromBody] UserPointsUpdateRequest request, string userId)
        {
            if (request.Action is null || request.Points == default)
                return BadRequest("Please check your request, {action} or {points}, value can't be null");

            var result = await _userService.UpdatePoints(request, userId);

            if (result.Errors != null && result.Errors.Contains("User not found"))
                return NotFound(string.Join(", ", result.Errors));

            if(!result.Success)
                return BadRequest(string.Join(", ", result.Errors));

            return NoContent();
        }

        /// <summary>
        /// Returns all user data by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.UsersRoutes.UserData)]
        public IActionResult UserData(string userId)
        {
            if (User is null)
                return NotFound("User not found, please re-login");

            var result = _userService.GetUserData(userId);

            if (!result.Success)
                return Problem(string.Join(", ", result.Errors.GetEnumerator()), null, 500);

            return Ok(new UserDataResponse
            {
                UserId = result.UserId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                BirthDate = result.BirthDate,
                Points = result.Points,
                ImgUrl = result.ImgUrl,
                RegDate = result.RegDate
            });
        }
    }
}