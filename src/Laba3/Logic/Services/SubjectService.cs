using Logic.DTOs.Subject;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Storage.Data;

namespace Logic.Services;

public class SubjectService : ISubjectService
{
    private readonly AppDbContext _context;

    public SubjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SubjectResponseDto>> GetAllAsync()
    {
        var subjects = await _context.Subjects
            .Include(s => s.University)
            .Include(s => s.HeadTeacher)
            .ToListAsync();

        return subjects.Select(MapToResponseDto);
    }

    public async Task<SubjectResponseDto?> GetByIdAsync(int id)
    {
        var subject = await _context.Subjects
            .Include(s => s.University)
            .Include(s => s.HeadTeacher)
            .FirstOrDefaultAsync(s => s.Id == id);

        return subject is null ? null : MapToResponseDto(subject);
    }

    public async Task<SubjectResponseDto> CreateAsync(SubjectCreateDto dto)
    {
        var universityExists = await _context.Universities.AnyAsync(u => u.Id == dto.UniversityId);
        if (!universityExists)
            throw new InvalidOperationException($"Вуз с Id={dto.UniversityId} не найден.");

        var subject = new Storage.Entities.Subject
        {
            Name = dto.Name,
            Description = dto.Description,
            UniversityId = dto.UniversityId
        };

        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();

        return (await GetByIdAsync(subject.Id))!;
    }

    public async Task<SubjectResponseDto?> UpdateAsync(SubjectUpdateDto dto)
    {
        var subject = await _context.Subjects
            .Include(s => s.University)
            .Include(s => s.HeadTeacher)
            .FirstOrDefaultAsync(s => s.Id == dto.Id);

        if (subject is null) return null;

        var universityExists = await _context.Universities.AnyAsync(u => u.Id == dto.UniversityId);
        if (!universityExists)
            throw new InvalidOperationException($"Вуз с Id={dto.UniversityId} не найден.");

        subject.Name = dto.Name;
        subject.Description = dto.Description;
        subject.UniversityId = dto.UniversityId;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(subject.Id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var subject = await _context.Subjects
            .Include(s => s.HeadTeacher)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (subject is null) return false;

        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();

        return true;
    }

    private static SubjectResponseDto MapToResponseDto(Storage.Entities.Subject subject)
    {
        return new SubjectResponseDto
        {
            Id = subject.Id,
            Name = subject.Name,
            Description = subject.Description,
            UniversityId = subject.UniversityId,
            UniversityName = subject.University?.Name ?? string.Empty,
            HeadTeacher = subject.HeadTeacher is not null
                ? new SubjectHeadTeacherDto
                {
                    Id = subject.HeadTeacher.Id,
                    FullName = subject.HeadTeacher.FullName,
                    ExperienceYears = subject.HeadTeacher.ExperienceYears,
                    Degree = subject.HeadTeacher.Degree
                }
                : null
        };
    }
}
