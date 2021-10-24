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
    public class DailyTestResultRepository : BaseRepository<DailyTestResult>, IDailyTestResultRepository
    {
        public DailyTestResultRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<IEnumerable<DailyTestResult>> GetByUserId(Guid id)
        {
            var result = await databaseContext.DailyTestResult.Where(o => o.PassedUserId.Id == id).Include(o => o.DailyTest).Include(o => o.PassedUserId).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<DailyTestResult>> GetByUserTestId(Guid userId, Guid testId)
        {
            var result = await databaseContext.DailyTestResult.Where(o => o.PassedUserId.Id == userId).Where(o => o.DailyTest.Id == testId).Include(o => o.DailyTest).Include(o => o.PassedUserId).ToListAsync();
            return result;
        }
    }
}
