using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IDailyTestService
    {
        public Task<IEnumerable<DailyTest>> Get();
        public Task<DailyTest> GetById(Guid id);
        public Task<DailyTest> Add(DailyTest dailyTest);
        public Task<DailyTest> Update(DailyTest dailyTest);
        public Task<DailyTest> DeleteById(Guid id);
    }
}
