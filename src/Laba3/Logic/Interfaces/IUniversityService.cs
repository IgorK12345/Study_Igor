using Logic.DTOs.University;

namespace Logic.Interfaces;

public interface IUniversityService
{
    Task<IEnumerable<UniversityResponseDto>> GetAllAsync();

    Task<UniversityResponseDto?> GetByIdAsync(int id);

    Task<UniversityResponseDto> CreateAsync(UniversityCreateDto dto);

    Task<UniversityResponseDto?> UpdateAsync(UniversityUpdateDto dto);

    Task<bool> DeleteAsync(int id);
}
