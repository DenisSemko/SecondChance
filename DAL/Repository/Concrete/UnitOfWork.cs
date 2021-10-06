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
