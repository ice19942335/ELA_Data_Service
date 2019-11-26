using System;
using System.Collections.Generic;

namespace ELA_Data_Service._Data.ElaDataContext.Models
{
    public partial class Users
    {
        public Users()
        {
            UserLessonStats = new HashSet<UserLessonStats>();
        }

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Points { get; set; }
        public string ImgUrl { get; set; }
        public DateTime RegDate { get; set; }

        public virtual ICollection<UserLessonStats> UserLessonStats { get; set; }
    }
}
