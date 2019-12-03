using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ELA_Data_Service.Contracts.V1.Requests.Users;
using ELA_Data_Service.Domain.Users.Dto;

namespace ELA_Data_Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserPointsUpdateDto> UpdatePoints(UserPointsUpdateRequest request, string userId);

        UserDataDto GetUserData(string userId);
    }
}
