using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IDailyTestResultRepository : IRepository<DailyTestResult>
    {
        public Task<IEnumerable<DailyTestResult>> GetByUserId(Guid id);
        public Task<IEnumerable<DailyTestResult>> GetByUserTestId(Guid userId, Guid testId);
    }
}
