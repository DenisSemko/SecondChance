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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            return Ok(await questionService.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Question>> GetById(Guid id)
        {
            try
            {
                var result = await questionService.GetById(id);
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
        public async Task<ActionResult<Question>> Add(QuestionDto question)
        {
            try
            {
                if (question == null)
                {
                    return BadRequest();
                }

                var result = await questionService.Add(question);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
