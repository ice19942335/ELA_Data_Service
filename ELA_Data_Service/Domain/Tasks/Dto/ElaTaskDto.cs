using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELA_Data_Service.Domain.Tasks.Dto
{
    public class ElaTaskDto
    {
        public int TaskId { get; set; }

        public int Points { get; set; }

        public int GivenWordId { get; set; }

        public string TaskType { get; set; }

        public string TaskDescription { get; set; }

        public string ImgUrl { get; set; }

        public string Transcription { get; set; }

        public string GivenWordEng { get; set; }

        public string GivenWordRus { get; set; }

        public IEnumerable<ElaGivenAnswerDto> GivenAnswers { get; set; }
    }
}
