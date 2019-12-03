using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELA_Data_Service._Data.ElaDataContext;
using ELA_Data_Service.Domain.Tasks;
using ELA_Data_Service.Domain.Tasks.Dto;
using ELA_Data_Service.Services.Interfaces;

namespace ELA_Data_Service.Services.Implementation
{
    public class TasksService : ITasksService
    {
        private readonly ElaDataContext _dataContext;

        public TasksService(ElaDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ElaRandomTasksDto GetRandomTasks(int amount)
        {
            #region Query

            var answersQuery =
                from bunch in _dataContext.BunchLessonTasks
                join task in _dataContext.Tasks on bunch.TasksId equals task.Id
                join answer in _dataContext.Answers on task.Id equals answer.TasksId
                join word in _dataContext.Words on answer.WordsId equals word.Id
                join taskType in _dataContext.TaskTypes on task.TaskTypesId equals taskType.Id
                join ansType in _dataContext.AnswersType on answer.AnswersTypeId equals ansType.Id
                select new
                {
                    TaskId = task.Id,
                    Points = task.Points,
                    GivenWordId = word.Id,
                    AnswerType = ansType.Type,
                    TaskType = taskType.Name,
                    TaskDescription = taskType.Description,
                    ImgUrl = word.ImgUrl,
                    Transcription = word.Transcript,
                    WordEng = word.Eng,
                    WordRus = word.Rus
                };

            #endregion

            var randomIdList = GenerateUniqueIdList(amount, answersQuery.Min(x => x.TaskId), answersQuery.Max(x => x.TaskId));

            var elaRandomTasksResult = new List<ElaTaskDto>();
            foreach (var id in randomIdList)
            {
                var answersEntryList = answersQuery.Where(x => x.TaskId == id).ToList();
                var correctAnswer = answersEntryList.Single(x => x.AnswerType.Equals("correct"));

                var elaTask = new ElaTaskDto
                {
                    TaskId = correctAnswer.TaskId,
                    Points = correctAnswer.Points,
                    GivenWordId = correctAnswer.GivenWordId,
                    TaskType = correctAnswer.TaskType,
                    TaskDescription = correctAnswer.TaskDescription,
                    ImgUrl = correctAnswer.ImgUrl,
                    Transcription = correctAnswer.Transcription,
                    GivenWordEng = correctAnswer.WordEng,
                    GivenWordRus = correctAnswer.WordRus
                };

                var givenAnswersList = new List<ElaGivenAnswerDto>();

                foreach (var answer in answersEntryList)
                {
                    givenAnswersList.Add(new ElaGivenAnswerDto
                    {
                        Type = answer.AnswerType,
                        Word =
                            answer.TaskType == "chooseRusWord" ? answer.WordRus :
                            answer.TaskType == "chooseEngWord" ? answer.WordEng :
                            answer.TaskType == "typeRusWord" ? answer.WordRus :
                            answer.TaskType == "typeEngWord" ? answer.WordEng : null
                    });
                }
                elaTask.GivenAnswers = givenAnswersList.AsEnumerable();

                elaRandomTasksResult.Add(elaTask);
            }

            return new ElaRandomTasksDto { TasksList = elaRandomTasksResult.AsEnumerable() };
        }

        public ElaTaskDto GetTaskById(int id)
        {
            ElaTaskDto elaTaskResult = new ElaTaskDto();

            #region Query

            var answersQuery =
                from bunch in _dataContext.BunchLessonTasks
                join task in _dataContext.Tasks on bunch.TasksId equals task.Id
                join answer in _dataContext.Answers on task.Id equals answer.TasksId
                join word in _dataContext.Words on answer.WordsId equals word.Id
                join taskType in _dataContext.TaskTypes on task.TaskTypesId equals taskType.Id
                join ansType in _dataContext.AnswersType on answer.AnswersTypeId equals ansType.Id
                where task.Id == id
                select new
                {
                    TaskId = task.Id,
                    Points = task.Points,
                    GivenWordId = word.Id,
                    AnswerType = ansType.Type,
                    TaskType = taskType.Name,
                    TaskDescription = taskType.Description,
                    ImgUrl = word.ImgUrl,
                    Transcription = word.Transcript,
                    WordEng = word.Eng,
                    WordRus = word.Rus
                };

            #endregion

            var correctAnswer = answersQuery.Single(x => x.AnswerType.Equals("correct"));
            elaTaskResult.TaskId = correctAnswer.TaskId;
            elaTaskResult.Points = correctAnswer.Points;
            elaTaskResult.GivenWordId = correctAnswer.GivenWordId;
            elaTaskResult.TaskType = correctAnswer.TaskType;
            elaTaskResult.TaskDescription = correctAnswer.TaskDescription;
            elaTaskResult.ImgUrl = correctAnswer.ImgUrl;
            elaTaskResult.Transcription = correctAnswer.Transcription;
            elaTaskResult.GivenWordEng = correctAnswer.WordEng;
            elaTaskResult.GivenWordRus = correctAnswer.WordRus;

            var answersList = new List<ElaGivenAnswerDto>();
            foreach (var answer in answersQuery)
            {
                answersList.Add(new ElaGivenAnswerDto
                {
                    Type = answer.AnswerType,
                    Word =
                        answer.TaskType == "chooseRusWord" ? answer.WordRus :
                        answer.TaskType == "chooseEngWord" ? answer.WordEng :
                        answer.TaskType == "typeRusWord" ? answer.WordRus :
                        answer.TaskType == "typeEngWord" ? answer.WordEng : null
                });
            }
            elaTaskResult.GivenAnswers = answersList.AsEnumerable();

            return elaTaskResult;
        }

        private List<int> GenerateUniqueIdList(int amount, int minId, int maxId)
        {
            var rnd = new Random();
            var randomIdList = new List<int>();

            do
            {
                int randomId = rnd.Next(minId, maxId);
                if (randomIdList.Contains(randomId))
                    continue;

                randomIdList.Add(randomId);

            } while (randomIdList.Count < amount);

            return randomIdList;
        }
    }
}
