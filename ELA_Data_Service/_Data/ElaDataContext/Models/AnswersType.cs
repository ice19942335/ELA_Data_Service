using System.Collections.Generic;

namespace ELA_Data_Service._Data.ElaDataContext.Models
{
    public partial class AnswersType
    {
        public AnswersType()
        {
            Answers = new HashSet<Answers>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Answers> Answers { get; set; }
    }
}
