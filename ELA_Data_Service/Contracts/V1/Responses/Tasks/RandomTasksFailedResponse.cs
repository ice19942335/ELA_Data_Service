using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELA_Data_Service.Contracts.V1.Responses.Tasks
{
    public class RandomTasksFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
