using BLL.Services.Abstract;
using CIL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class DailyTestService : IDailyTestService
    {
        private readonly IUnitOfWork unitOfWork;
        public DailyTestService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DailyTest>> Get()
        {
            return await unitOfWork.DailyTestRepository.Get();
        }

        public async Task<DailyTest> GetById(Guid id)
        {
            var result = await unitOfWork.DailyTestRepository.GetById(id);
            return result;
        }

        public async Task<DailyTest> Add(DailyTest dailyTest)
        {
            var result = await unitOfWork.DailyTestRepository.Add(dailyTest);
            return result;
        }

        public async Task<DailyTest> Update(DailyTest dailyTest)
        {
            var result = await unitOfWork.DailyTestRepository.Update(dailyTest);
            return result;
        }

        public async Task<DailyTest> DeleteById(Guid id)
        {
            var result = await unitOfWork.DailyTestRepository.DeleteById(id);
            return result;
        }
    }
}
