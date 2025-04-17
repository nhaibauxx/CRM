using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Application.Interfaces;
using CRM.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationLevelsController : ControllerBase
    {
        private readonly IEducationLevelService _educationLevelService;

        public EducationLevelsController(IEducationLevelService educationLevelService)
        {
            _educationLevelService = educationLevelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EducationLevelDto>>> GetAll()
        {
            var educationLevels = await _educationLevelService.GetAllAsync();
            return Ok(educationLevels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationLevelDto>> GetById(int id)
        {
            var educationLevel = await _educationLevelService.GetByIdAsync(id);
            if (educationLevel == null)
                return NotFound();

            return Ok(educationLevel);
        }

        [HttpPost]
        public async Task<ActionResult<EducationLevelDto>> Create([FromBody] CreateEducationLevelDto dto)
        {
            var educationLevel = await _educationLevelService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = educationLevel.Id }, educationLevel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EducationLevelDto>> Update(int id, [FromBody] UpdateEducationLevelDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var educationLevel = await _educationLevelService.UpdateAsync(dto);
            if (educationLevel == null)
                return NotFound();

            return Ok(educationLevel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _educationLevelService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
} 