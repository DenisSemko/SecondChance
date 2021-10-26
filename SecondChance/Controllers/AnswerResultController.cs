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
    public class AnswerResultController : ControllerBase
    {
        private readonly IAnswersService answersService;

        public AnswerResultController(IAnswersService answersService)
        {
            this.answersService = answersService;
        }

        [HttpGet("{userId:Guid}/{testId:Guid}")]
        public async Task<ActionResult> CheckTheAnswers(Guid userId, Guid testId)
        {
            try
            {
                
                await answersService.CheckTheAnswers(userId, testId);

                return StatusCode(200);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
