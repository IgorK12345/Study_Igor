using Logic.DTOs.Subject;

namespace Logic.Interfaces;

public interface ISubjectService
{
    Task<IEnumerable<SubjectResponseDto>> GetAllAsync();

    Task<SubjectResponseDto?> GetByIdAsync(int id);

    Task<SubjectResponseDto> CreateAsync(SubjectCreateDto dto);

    Task<SubjectResponseDto?> UpdateAsync(SubjectUpdateDto dto);

    Task<bool> DeleteAsync(int id);
}
