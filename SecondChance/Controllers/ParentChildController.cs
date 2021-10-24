using BLL.Services.Abstract;
using CIL.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class ParentChildController : ControllerBase
    {
        private readonly IParentChildService parentChildService;

        public ParentChildController(IParentChildService parentChildService)
        {
            this.parentChildService = parentChildService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentChild>>> Get()
        {
            return Ok(await parentChildService.Get());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ParentChild>> GetById(Guid id)
        {
            try
            {
                var result = await parentChildService.GetById(id);
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
        public async Task<ActionResult<ParentChild>> Add(ParentChild parentChild)
        {
            try
            {
                if (parentChild == null)
                {
                    return BadRequest();
                }

                var result = await parentChildService.Add(parentChild);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
