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
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<Question>> GetByTestId(Guid id)
        {
            var result = await databaseContext.Question.Where(o => o.DailyTest.Id == id).Include(o => o.DailyTest).Include(o => o.DailyTest).ToListAsync();
            return result;
        }
    }
}
