using System.Collections.Generic;

namespace ELA_Data_Service.Domain.Tasks.Dto
{
    public class RandomTasksDto
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

        public IEnumerable<GivenAnswerDto> GivenAnswers { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
