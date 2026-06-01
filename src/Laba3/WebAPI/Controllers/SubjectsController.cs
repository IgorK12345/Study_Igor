using Logic.DTOs.Subject;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectsController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectsController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SubjectResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SubjectResponseDto>>> GetAll()
    {
        var subjects = await _subjectService.GetAllAsync();
        return Ok(subjects);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SubjectResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SubjectResponseDto>> GetById(int id)
    {
        var subject = await _subjectService.GetByIdAsync(id);
        if (subject is null)
            return NotFound(new { message = $"Предмет с Id={id} не найден." });

        return Ok(subject);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SubjectResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubjectResponseDto>> Create([FromBody] SubjectCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var created = await _subjectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SubjectResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubjectResponseDto>> Update(int id, [FromBody] SubjectUpdateDto dto)
    {
        if (id != dto.Id)
            return BadRequest(new { message = "Id в URL и в теле запроса не совпадают." });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var updated = await _subjectService.UpdateAsync(dto);
            if (updated is null)
                return NotFound(new { message = $"Предмет с Id={id} не найден." });

            return Ok(updated);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _subjectService.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Предмет с Id={id} не найден." });

        return NoContent();
    }
}
