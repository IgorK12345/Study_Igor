using Logic.DTOs.HeadTeacher;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Storage.Data;

namespace Logic.Services;

public class HeadTeacherService : IHeadTeacherService
{
    private readonly AppDbContext _context;

    public HeadTeacherService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HeadTeacherResponseDto>> GetAllAsync()
    {
        var teachers = await _context.HeadTeachers
            .Include(ht => ht.Subject)
                .ThenInclude(s => s!.University)
            .ToListAsync();

        return teachers.Select(MapToResponseDto);
    }

    public async Task<HeadTeacherResponseDto?> GetByIdAsync(int id)
    {
        var teacher = await _context.HeadTeachers
            .Include(ht => ht.Subject)
                .ThenInclude(s => s!.University)
            .FirstOrDefaultAsync(ht => ht.Id == id);

        return teacher is null ? null : MapToResponseDto(teacher);
    }

    public async Task<HeadTeacherResponseDto> CreateAsync(HeadTeacherCreateDto dto)
    {
        var subjectExists = await _context.Subjects.AnyAsync(s => s.Id == dto.SubjectId);
        if (!subjectExists)
            throw new InvalidOperationException($"Предмет с Id={dto.SubjectId} не найден.");

        var alreadyAssigned = await _context.HeadTeachers.AnyAsync(ht => ht.SubjectId == dto.SubjectId);
        if (alreadyAssigned)
            throw new InvalidOperationException($"На кафедре (SubjectId={dto.SubjectId}) уже назначен главный преподаватель.");

        var teacher = new Storage.Entities.HeadTeacher
        {
            FullName = dto.FullName,
            ExperienceYears = dto.ExperienceYears,
            Degree = dto.Degree,
            SubjectId = dto.SubjectId
        };

        _context.HeadTeachers.Add(teacher);
        await _context.SaveChangesAsync();

        return (await GetByIdAsync(teacher.Id))!;
    }

    public async Task<HeadTeacherResponseDto?> UpdateAsync(HeadTeacherUpdateDto dto)
    {
        var teacher = await _context.HeadTeachers
            .Include(ht => ht.Subject)
                .ThenInclude(s => s!.University)
            .FirstOrDefaultAsync(ht => ht.Id == dto.Id);

        if (teacher is null) return null;

        if (teacher.SubjectId != dto.SubjectId)
        {
            var subjectExists = await _context.Subjects.AnyAsync(s => s.Id == dto.SubjectId);
            if (!subjectExists)
                throw new InvalidOperationException($"Предмет с Id={dto.SubjectId} не найден.");

            var alreadyAssigned = await _context.HeadTeachers.AnyAsync(ht => ht.SubjectId == dto.SubjectId);
            if (alreadyAssigned)
                throw new InvalidOperationException($"На кафедре (SubjectId={dto.SubjectId}) уже назначен главный преподаватель.");
        }

        teacher.FullName = dto.FullName;
        teacher.ExperienceYears = dto.ExperienceYears;
        teacher.Degree = dto.Degree;
        teacher.SubjectId = dto.SubjectId;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(teacher.Id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var teacher = await _context.HeadTeachers.FindAsync(id);
        if (teacher is null) return false;

        _context.HeadTeachers.Remove(teacher);
        await _context.SaveChangesAsync();

        return true;
    }

    private static HeadTeacherResponseDto MapToResponseDto(Storage.Entities.HeadTeacher teacher)
    {
        return new HeadTeacherResponseDto
        {
            Id = teacher.Id,
            FullName = teacher.FullName,
            ExperienceYears = teacher.ExperienceYears,
            Degree = teacher.Degree,
            SubjectId = teacher.SubjectId,
            SubjectName = teacher.Subject?.Name ?? string.Empty,
            UniversityName = teacher.Subject?.University?.Name ?? string.Empty
        };
    }
}
