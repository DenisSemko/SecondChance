﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CIL.Models;

namespace DAL.Repository.Abstract
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        public Task<IEnumerable<Answer>> GetByUserId(Guid id);
        public Task<IEnumerable<Answer>> GetByUserTestId(Guid userId, Guid testId);
        public Task<IEnumerable<Answer>> GetAllAnswers(Guid userId, Guid testId);
        public Task<Answer> GetByUserTestQuestionId(Guid userId, Guid testId, Guid questionId);
    }
}
