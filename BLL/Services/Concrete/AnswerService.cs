using BLL.Services.Abstract;
using CIL.Models;
using DAL;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using CIL.DTOs;

namespace BLL.Services.Concrete
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DatabaseContext databaseContext;
        public AnswerService(IUnitOfWork unitOfWork, DatabaseContext databaseContext)
        {
            this.unitOfWork = unitOfWork;
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Answer>> Get()
        {
            return await unitOfWork.AnswerRepository.Get();
        }

        public async Task<IEnumerable<Answer>> GetByUserId(Guid id)
        {
            var result = await unitOfWork.AnswerRepository.GetByUserId(id);
            return result;
        }

        public async Task<IEnumerable<Answer>> GetByUserTestId(Guid userId, Guid testId)
        {
            var result = await unitOfWork.AnswerRepository.GetByUserTestId(userId, testId);
            return result;
        }

        public async Task<Answer> GetByUserTestQuestionId(Guid userId, Guid testId, Guid questionId)
        {
            var result = await unitOfWork.AnswerRepository.GetByUserTestQuestionId(userId, testId, questionId);
            return result;
        }

        public async Task<Answer> Add(AnswerDto answerDto)
        {
            var dailyTest = await databaseContext.DailyTest.Where(x => x.Id == answerDto.DailyTest).FirstOrDefaultAsync();
            var user = await databaseContext.Users.Where(x => x.Id == answerDto.PassedUserId).FirstOrDefaultAsync();
            var question = await databaseContext.Question.Where(x => x.Id == answerDto.Question).FirstOrDefaultAsync();
            var answer = new Answer()
            {
                Id = answerDto.Id,
                PassedUserId = user,
                DailyTest = dailyTest,
                Question = question,
                QuestionAnswer = answerDto.QuestionAnswer,
                DateBegin = answerDto.DateBegin,
                DateEnd = answerDto.DateEnd,
                Score = answerDto.Score
            };
            var result = await unitOfWork.AnswerRepository.Add(answer);
            return result;
        }

        public async Task<Answer> Update(AnswerDto answerDto)
        {
            var dailyTest = await databaseContext.DailyTest.Where(x => x.Id == answerDto.DailyTest).FirstOrDefaultAsync();
            var user = await databaseContext.Users.Where(x => x.Id == answerDto.PassedUserId).FirstOrDefaultAsync();
            var question = await databaseContext.Question.Where(x => x.Id == answerDto.Question).FirstOrDefaultAsync();
            var answer = new Answer()
            {
                Id = answerDto.Id,
                PassedUserId = user,
                DailyTest = dailyTest,
                Question = question,
                QuestionAnswer = answerDto.QuestionAnswer,
                DateBegin = answerDto.DateBegin,
                DateEnd = answerDto.DateEnd,
                Score = answerDto.Score
            };
            var result = await unitOfWork.AnswerRepository.Update(answer);
            return result;
        }
    }
}
