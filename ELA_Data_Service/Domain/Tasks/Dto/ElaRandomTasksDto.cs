using System.Collections.Generic;

namespace ELA_Data_Service.Domain.Tasks.Dto
{
    public class ElaRandomTasksDto
    {
        public IEnumerable<ElaTaskDto> Tasks { get; set; }
    }
}
