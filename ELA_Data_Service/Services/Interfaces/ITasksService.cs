using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service.Domain.Tasks.Dto;

namespace ELA_Data_Service.Services.Interfaces
{
    public interface ITasksService
    {
        ElaRandomTasksDto GetRandomTasks(int amount);

        ElaTaskDto GetTaskById(int id);
    }
}
