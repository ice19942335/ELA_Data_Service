using System.Collections.Generic;

namespace ELA_Data_Service._Data.ElaDataContext.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            Answers = new HashSet<Answers>();
            BunchLessonTasks = new HashSet<BunchLessonTasks>();
        }

        public int Id { get; set; }
        public int TaskTypesId { get; set; }
        public int Points { get; set; }

        public virtual TaskTypes TaskTypes { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<BunchLessonTasks> BunchLessonTasks { get; set; }
    }
}
