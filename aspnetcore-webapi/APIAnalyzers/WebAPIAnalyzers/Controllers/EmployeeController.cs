﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebAPIAnalyzers.Controllers
{
    //[ApiConventionType(typeof(CustomConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IFakeRepository _repository;

        public EmployeeController(IFakeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        //[ApiConventionMethod(typeof(CustomConventions), nameof(CustomConventions.GetByIdConvention))]
        public IActionResult GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            if (!_repository.TryGetEmployee(id, out var employee))
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
