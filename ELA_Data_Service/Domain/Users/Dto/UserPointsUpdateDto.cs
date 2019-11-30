using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELA_Data_Service.Domain.Users.Dto
{
    public class UserPointsUpdateDto
    {
        public IEnumerable<string> Errors { get; set; }

        public bool Success { get; set; }
    }
}
