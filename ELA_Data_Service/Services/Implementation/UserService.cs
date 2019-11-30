using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service._Data.ElaDataContext;
using ELA_Data_Service.Contracts.V1.Requests.Users;
using ELA_Data_Service.Domain.Users.Dto;
using ELA_Data_Service.Services.Interfaces;

namespace ELA_Data_Service.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ElaDataContext _dataContext;

        public UserService(ElaDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserPointsUpdateDto> UpdatePoints(UserPointsUpdateRequest request, string userId)
        {
            var user = _dataContext.Users.FirstOrDefault(x => x.UserId == userId);

            if (user is null)
                return new UserPointsUpdateDto { Errors = new[] { "User not found" } };

            if (request.Action.Equals("reduce"))
            {
                if (user.Points - request.Points < 0)
                    return new UserPointsUpdateDto { Errors = new[] { "User don't have enough points" } };

                user.Points -= request.Points;
                await _dataContext.SaveChangesAsync();
                return new UserPointsUpdateDto { Success = true };
            }
            else if(request.Action.Equals("add"))
            {
                user.Points += request.Points;
                await _dataContext.SaveChangesAsync();
                return new UserPointsUpdateDto { Success = true };
            }
            else
            {
                return new UserPointsUpdateDto { Errors = new[] { "Action should be \"add\" or \"reduce\" only" } };
            }
        }
    }

}

