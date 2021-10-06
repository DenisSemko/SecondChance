using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstract
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IParentChildRepository ParentChildRepository { get; }
        IDailyTestRepository DailyTestRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; }
        IGameRepository GameRepository { get; }
        IDairyRepository DairyRepository { get; }
        void Complete();
        bool HasChanges();
    }
}
