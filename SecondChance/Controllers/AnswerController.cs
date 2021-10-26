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
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService answerService;

        public AnswerController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IEnumerable<Answer>> GetByUserId(Guid id)
        {
            try
            {
                var result = await answerService.GetByUserId(id);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{userId:Guid}/{testId:Guid}")]
        public async Task<IEnumerable<Answer>> GetByUserTestId(Guid userId, Guid testId)
        {
            try
            {
                var result = await answerService.GetByUserTestId(userId, testId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Answer>> Add(AnswerDto answerDto)
        {
            try
            {
                if (answerDto == null)
                {
                    return BadRequest();
                }

                var result = await answerService.Add(answerDto);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<Answer>> Update(AnswerDto answerDto)
        {
            var result = await answerService.Update(answerDto);
            return result;
        }
    }
}
