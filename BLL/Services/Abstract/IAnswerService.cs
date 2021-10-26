using CIL.DTOs;
using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IAnswerService
    {
        public Task<IEnumerable<Answer>> Get();
        public Task<IEnumerable<Answer>> GetByUserId(Guid id);
        public Task<IEnumerable<Answer>> GetByUserTestId(Guid userId, Guid testId);
        public Task<Answer> GetByUserTestQuestionId(Guid userId, Guid testId, Guid questionId);
        public Task<Answer> Add(AnswerDto answerDto);
        public Task<Answer> Update(AnswerDto item);
    }
}
