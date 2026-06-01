using Logic.DTOs.University;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

/// <summary>
/// Контроллер для работы с вузами.
/// Маршрут: api/universities
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UniversitiesController : ControllerBase
{
    private readonly IUniversityService _universityService;

    public UniversitiesController(IUniversityService universityService)
    {
        _universityService = universityService;
    }

    /// <summary>
    /// GET api/universities — получить список всех вузов.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UniversityResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UniversityResponseDto>>> GetAll()
    {
        var universities = await _universityService.GetAllAsync();
        return Ok(universities);
    }

    /// <summary>
    /// GET api/universities/{id} — получить вуз по идентификатору.
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UniversityResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UniversityResponseDto>> GetById(int id)
    {
        var university = await _universityService.GetByIdAsync(id);
        if (university is null)
            return NotFound(new { message = $"Вуз с Id={id} не найден." });

        return Ok(university);
    }

    /// <summary>
    /// POST api/universities — создать новый вуз.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(UniversityResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UniversityResponseDto>> Create([FromBody] UniversityCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _universityService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// PUT api/universities/{id} — обновить данные вуза.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UniversityResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UniversityResponseDto>> Update(int id, [FromBody] UniversityUpdateDto dto)
    {
        if (id != dto.Id)
            return BadRequest(new { message = "Id в URL и в теле запроса не совпадают." });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _universityService.UpdateAsync(dto);
        if (updated is null)
            return NotFound(new { message = $"Вуз с Id={id} не найден." });

        return Ok(updated);
    }

    /// <summary>
    /// DELETE api/universities/{id} — удалить вуз.
    /// Нельзя удалить вуз, у которого есть предметы.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _universityService.DeleteAsync(id);
        if (!deleted)
        {
            var exists = await _universityService.GetByIdAsync(id);
            if (exists is null)
                return NotFound(new { message = $"Вуз с Id={id} не найден." });

            return Conflict(new { message = "Нельзя удалить вуз, у которого есть предметы. Сначала удалите предметы." });
        }

        return NoContent();
    }
}
