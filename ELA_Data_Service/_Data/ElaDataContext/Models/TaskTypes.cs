using System.Collections.Generic;

namespace ELA_Data_Service._Data.ElaDataContext.Models
{
    public partial class TaskTypes
    {
        public TaskTypes()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
