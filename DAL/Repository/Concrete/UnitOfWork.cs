using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IUserRepository UserRepository => new UserRepository(databaseContext);
        public IParentChildRepository ParentChildRepository => new ParentChildRepository(databaseContext);
        public IDailyTestRepository DailyTestRepository => new DailyTestRepository(databaseContext);
        public IQuestionRepository QuestionRepository => new QuestionRepository(databaseContext);
        public IAnswerRepository AnswerRepository => new AnswerRepository(databaseContext);
        public IGameRepository GameRepository => new GameRepository(databaseContext);
        public IDairyRepository DairyRepository => new DairyRepository(databaseContext);
        public IDailyTestResultRepository DailyTestResultRepository => new DailyTestResultRepository(databaseContext);

        public void Complete()
        {
            databaseContext.SaveChangesAsync();
        }

        public bool HasChanges()
        {
            databaseContext.ChangeTracker.DetectChanges();
            var changes = databaseContext.ChangeTracker.HasChanges();

            return changes;
        }
    }
}
