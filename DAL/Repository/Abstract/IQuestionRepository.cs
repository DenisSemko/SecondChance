using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CIL.Models;

namespace DAL.Repository.Abstract
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public Task<IEnumerable<Question>> GetByTestId(Guid id);
    }
}
