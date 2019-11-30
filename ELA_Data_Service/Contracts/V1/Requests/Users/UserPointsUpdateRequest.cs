using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELA_Data_Service.Contracts.V1.Requests.Users
{
    public class UserPointsUpdateRequest
    {
        public string Action { get; set; }  

        public int Points { get; set; }  
    }
}
