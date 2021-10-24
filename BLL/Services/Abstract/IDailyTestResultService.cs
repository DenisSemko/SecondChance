using CIL.DTOs;
using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IDailyTestResultService
    {
        public Task<IEnumerable<DailyTestResult>> Get();
        public Task<IEnumerable<DailyTestResult>> GetByUserId(Guid id);
        public Task<IEnumerable<DailyTestResult>> GetByUserTestId(Guid userId, Guid testId);
        public Task<DailyTestResult> Add(DailyTestResultDto dailyTestResultDto);
    }
}
