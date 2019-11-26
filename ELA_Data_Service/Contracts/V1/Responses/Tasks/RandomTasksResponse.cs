using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service.Domain;
using ELA_Data_Service.Domain.Tasks;
using ELA_Data_Service.Domain.Tasks.Dto;

namespace ELA_Data_Service.Contracts.V1.Responses.Tasks
{
    public class RandomTasksResponse
    {
        public IEnumerable<ElaTaskDto> Tasks { get; set; }
    }
}
