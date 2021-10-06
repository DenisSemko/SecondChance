using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
