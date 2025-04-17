using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Application.Interfaces;
using CRM.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationsController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EducationDto>>> GetAll()
        {
            var educations = await _educationService.GetAllAsync();
            return Ok(educations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationDto>> GetById(int id)
        {
            var education = await _educationService.GetByIdAsync(id);
            if (education == null)
                return NotFound();

            return Ok(education);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<List<EducationDto>>> GetByEmployeeId(int employeeId)
        {
            var educations = await _educationService.GetByEmployeeIdAsync(employeeId);
            return Ok(educations);
        }

        [HttpPost]
        public async Task<ActionResult<EducationDto>> Create([FromBody] CreateEducationDto dto)
        {
            var education = await _educationService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = education.Id }, education);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EducationDto>> Update(int id, [FromBody] UpdateEducationDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var education = await _educationService.UpdateAsync(dto);
            if (education == null)
                return NotFound();

            return Ok(education);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _educationService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
} 