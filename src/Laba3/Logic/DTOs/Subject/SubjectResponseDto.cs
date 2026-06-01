namespace Logic.DTOs.Subject;

public class SubjectResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int UniversityId { get; set; }

    public string UniversityName { get; set; } = string.Empty;

    public SubjectHeadTeacherDto? HeadTeacher { get; set; }
}

public class SubjectHeadTeacherDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public int ExperienceYears { get; set; }

    public string Degree { get; set; } = string.Empty;
}
