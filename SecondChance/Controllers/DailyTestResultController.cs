using BLL.Services.Abstract;
using CIL.DTOs;
using CIL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondChance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTestResultController : ControllerBase
    {
        private readonly IDailyTestResultService dailyTestResultService;

        public DailyTestResultController(IDailyTestResultService dailyTestResultService)
        {
            this.dailyTestResultService = dailyTestResultService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyTestResult>>> Get()
        {
            return Ok(await dailyTestResultService.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IEnumerable<DailyTestResult>> GetByUserId(Guid id)
        {
            try
            {
                var result = await dailyTestResultService.GetByUserId(id);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{userId:Guid}/{testId:Guid}")]
        public async Task<IEnumerable<DailyTestResult>> GetByUserTestId(Guid userId, Guid testId)
        {
            try
            {
                var result = await dailyTestResultService.GetByUserTestId(userId, testId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<DailyTestResult>> Add(DailyTestResultDto dailyTestResultDto)
        {
            try
            {
                if (dailyTestResultDto == null)
                {
                    return BadRequest();
                }

                var result = await dailyTestResultService.Add(dailyTestResultDto);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
