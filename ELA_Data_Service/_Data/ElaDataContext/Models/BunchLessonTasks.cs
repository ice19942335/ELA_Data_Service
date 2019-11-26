namespace ELA_Data_Service._Data.ElaDataContext.Models
{
    public partial class BunchLessonTasks
    {
        public int Id { get; set; }
        public int LessonsId { get; set; }
        public int TasksId { get; set; }

        public virtual Lessons Lessons { get; set; }
        public virtual Tasks Tasks { get; set; }
    }
}
