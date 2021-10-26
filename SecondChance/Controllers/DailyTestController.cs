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
    public class DailyTestController : ControllerBase
    {
        private readonly IDailyTestService dailyTestService;

        public DailyTestController(IDailyTestService dailyTestService)
        {
            this.dailyTestService = dailyTestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyTest>>> Get()
        {
            return Ok(await dailyTestService.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<DailyTest>> GetById(Guid id)
        {
            try
            {
                var result = await dailyTestService.GetById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DailyTest>> Add(DailyTest dailyTest)
        {
            try
            {
                if (dailyTest == null)
                {
                    return BadRequest();
                }

                var result = await dailyTestService.Add(dailyTest);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut]
        public async Task<ActionResult<DailyTest>> Update(DailyTest dailyTest)
        {
            var result = await dailyTestService.Update(dailyTest);
            return result;
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<DailyTest>> DeleteById(Guid id)
        {
            try
            {
                var result = await dailyTestService.DeleteById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting the treatment record");
            }
        }
    }
}
