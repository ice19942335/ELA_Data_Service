namespace ELA_Data_Service._Data.ElaDataContext.Models
{
    public partial class UserLessonStats
    {
        public int Id { get; set; }
        public string UsersId { get; set; }
        public int LessonsId { get; set; }
        public int ComplTasksCounter { get; set; }

        public virtual Lessons Lessons { get; set; }
        public virtual Users Users { get; set; }
    }
}
