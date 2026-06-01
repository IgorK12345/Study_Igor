using Logic.DTOs.HeadTeacher;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeadTeachersController : ControllerBase
{
    private readonly IHeadTeacherService _headTeacherService;

    public HeadTeachersController(IHeadTeacherService headTeacherService)
    {
        _headTeacherService = headTeacherService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HeadTeacherResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<HeadTeacherResponseDto>>> GetAll()
    {
        var teachers = await _headTeacherService.GetAllAsync();
        return Ok(teachers);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(HeadTeacherResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<HeadTeacherResponseDto>> GetById(int id)
    {
        var teacher = await _headTeacherService.GetByIdAsync(id);
        if (teacher is null)
            return NotFound(new { message = $"Преподаватель с Id={id} не найден." });

        return Ok(teacher);
    }

    [HttpPost]
    [ProducesResponseType(typeof(HeadTeacherResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HeadTeacherResponseDto>> Create([FromBody] HeadTeacherCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var created = await _headTeacherService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(HeadTeacherResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HeadTeacherResponseDto>> Update(int id, [FromBody] HeadTeacherUpdateDto dto)
    {
        if (id != dto.Id)
            return BadRequest(new { message = "Id в URL и в теле запроса не совпадают." });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var updated = await _headTeacherService.UpdateAsync(dto);
            if (updated is null)
                return NotFound(new { message = $"Преподаватель с Id={id} не найден." });

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
        var deleted = await _headTeacherService.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Преподаватель с Id={id} не найден." });

        return NoContent();
    }
}
