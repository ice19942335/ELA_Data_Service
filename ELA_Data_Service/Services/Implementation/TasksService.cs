using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service.Domain.Tasks.Dto;
using ELA_Data_Service.Services.Interfaces;

namespace ELA_Data_Service.Services.Implementation
{
    public class TasksService : ITasksService
    {

        public TasksService()
        {
            
        }


        public Task<RandomTasksDto> GetRandomTasks(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
