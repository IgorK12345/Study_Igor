namespace Logic.DTOs.HeadTeacher;

public class HeadTeacherResponseDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public int ExperienceYears { get; set; }

    public string Degree { get; set; } = string.Empty;

    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = string.Empty;

    public string UniversityName { get; set; } = string.Empty;
}
