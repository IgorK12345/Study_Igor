using Logic.DTOs.University;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Storage.Data;

namespace Logic.Services;

public class UniversityService : IUniversityService
{
    private readonly AppDbContext _context;

    public UniversityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UniversityResponseDto>> GetAllAsync()
    {
        var universities = await _context.Universities
            .Include(u => u.Subjects)
            .ToListAsync();

        return universities.Select(MapToResponseDto);
    }

    public async Task<UniversityResponseDto?> GetByIdAsync(int id)
    {
        var university = await _context.Universities
            .Include(u => u.Subjects)
            .FirstOrDefaultAsync(u => u.Id == id);

        return university is null ? null : MapToResponseDto(university);
    }

    public async Task<UniversityResponseDto> CreateAsync(UniversityCreateDto dto)
    {
        var university = new Storage.Entities.University
        {
            Name = dto.Name,
            Address = dto.Address
        };

        _context.Universities.Add(university);
        await _context.SaveChangesAsync();

        return (await GetByIdAsync(university.Id))!;
    }

    public async Task<UniversityResponseDto?> UpdateAsync(UniversityUpdateDto dto)
    {
        var university = await _context.Universities
            .Include(u => u.Subjects)
            .FirstOrDefaultAsync(u => u.Id == dto.Id);

        if (university is null) return null;

        university.Name = dto.Name;
        university.Address = dto.Address;

        await _context.SaveChangesAsync();

        return MapToResponseDto(university);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var university = await _context.Universities
            .Include(u => u.Subjects)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (university is null) return false;

        if (university.Subjects.Any())
            return false;

        _context.Universities.Remove(university);
        await _context.SaveChangesAsync();

        return true;
    }

    private static UniversityResponseDto MapToResponseDto(Storage.Entities.University university)
    {
        return new UniversityResponseDto
        {
            Id = university.Id,
            Name = university.Name,
            Address = university.Address,
            Subjects = university.Subjects.Select(s => new UniversitySubjectDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            }).ToList()
        };
    }
}
