using CIL.DTOs;
using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IQuestionService
    {
        public Task<IEnumerable<Question>> Get();
        public Task<Question> GetById(Guid id);
        public Task<IEnumerable<Question>> GetByTestId(Guid id);
        public Task<Question> Add(Question question);
        public Task<Question> Add(QuestionDto question);
    }
}
