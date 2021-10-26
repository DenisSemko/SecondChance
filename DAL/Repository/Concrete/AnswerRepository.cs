using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIL.Models;
using DAL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Concrete
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<Answer>> GetByUserId(Guid id)
        {
            var result = await databaseContext.Answer.Where(o => o.PassedUserId.Id == id).Include(o => o.DailyTest).Include(o => o.PassedUserId).Include(o => o.Question).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Answer>> GetAllAnswers(Guid userId, Guid testId)
        {
            var result = await databaseContext.Answer.Where(a => a.PassedUserId.Id == userId).Where(a => a.DailyTest.Id == testId).Where(a => a.DateBegin.Value.Day == DateTime.Now.Day).ToListAsync();
            return result;

        }
        public async Task<IEnumerable<Answer>> GetByUserTestId(Guid userId, Guid testId)
        {
            var result = await databaseContext.Answer.Where(a => a.PassedUserId.Id == userId).Where(a => a.DailyTest.Id == testId).ToListAsync();
            return result;
        }

        public async Task<Answer> GetByUserTestQuestionId(Guid userId, Guid testId, Guid questionId)
        {
            var result = await databaseContext.Answer.Where(a => a.PassedUserId.Id == userId).Where(a => a.DailyTest.Id == testId).Where(a => a.Question.Id == questionId).Where(a => a.DateBegin.Value.Day == DateTime.Now.Day).FirstOrDefaultAsync();
            return result;
        }

    }
}
