using BLL.Services.Abstract;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using System.Threading.Tasks;
using CIL.DTOs;
using DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Concrete
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DatabaseContext databaseContext;

        public QuestionService(IUnitOfWork unitOfWork, DatabaseContext databaseContext)
        {
            this.unitOfWork = unitOfWork;
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Question>> Get()
        {
            return await unitOfWork.QuestionRepository.Get();
        }

        public async Task<Question> GetById(Guid id)
        {
            var result = await unitOfWork.QuestionRepository.GetById(id);
            return result;
        }

        public async Task<Question> Add(Question question)
        {
            var result = await unitOfWork.QuestionRepository.Add(question);
            return result;
        }
        public async Task<Question> Add(QuestionDto questionDto)
        {
            var dailyTest = await databaseContext.DailyTest.Where(x => x.Id == questionDto.DailyTest).FirstOrDefaultAsync();
            var question = new Question()
            {
                Id = questionDto.Id,
                DailyTest = dailyTest,
                Description = questionDto.Description,
                DifficultyLevel = questionDto.DifficultyLevel,
                CorrectAnswer = questionDto.CorrectAnswer
            };
            var result = await unitOfWork.QuestionRepository.Add(question);
            return result;
        }
    }
}
