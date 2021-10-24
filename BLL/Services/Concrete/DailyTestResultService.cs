using BLL.Services.Abstract;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using System.Threading.Tasks;
using DAL;
using CIL.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Concrete
{
    public class DailyTestResultService : IDailyTestResultService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DatabaseContext databaseContext;

        public DailyTestResultService(IUnitOfWork unitOfWork, DatabaseContext databaseContext)
        {
            this.unitOfWork = unitOfWork;
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<DailyTestResult>> Get()
        {
            return await unitOfWork.DailyTestResultRepository.Get();
        }

        public async Task<IEnumerable<DailyTestResult>> GetByUserId(Guid id)
        {
            var result = await unitOfWork.DailyTestResultRepository.GetByUserId(id);
            return result;
        }

        public async Task<IEnumerable<DailyTestResult>> GetByUserTestId(Guid userId, Guid testId)
        {
            var result = await unitOfWork.DailyTestResultRepository.GetByUserTestId(userId, testId);
            return result;
        }

        public async Task<DailyTestResult> Add(DailyTestResultDto dailyTestResultDto)
        {
            var dailyTest = await databaseContext.DailyTest.Where(x => x.Id == dailyTestResultDto.DailyTest).FirstOrDefaultAsync();
            var user = await databaseContext.Users.Where(x => x.Id == dailyTestResultDto.PassedUserId).FirstOrDefaultAsync();
            var testResult = new DailyTestResult()
            {
                Id = dailyTestResultDto.Id,
                DailyTest = dailyTest,
                PassedUserId = user,
                Score = dailyTestResultDto.Score,
                Description = dailyTestResultDto.Description
            };
            var result = await unitOfWork.DailyTestResultRepository.Add(testResult);
            return result;
        }
    }
}
