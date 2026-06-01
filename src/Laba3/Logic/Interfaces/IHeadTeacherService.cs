using Logic.DTOs.HeadTeacher;

namespace Logic.Interfaces;

public interface IHeadTeacherService
{
    Task<IEnumerable<HeadTeacherResponseDto>> GetAllAsync();

    Task<HeadTeacherResponseDto?> GetByIdAsync(int id);

    Task<HeadTeacherResponseDto> CreateAsync(HeadTeacherCreateDto dto);

    Task<HeadTeacherResponseDto?> UpdateAsync(HeadTeacherUpdateDto dto);

    Task<bool> DeleteAsync(int id);
}
