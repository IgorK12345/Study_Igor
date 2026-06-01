namespace Storage.Entities;

public class HeadTeacher
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public int ExperienceYears { get; set; }

    public string Degree { get; set; } = string.Empty;

    public int SubjectId { get; set; }

    public Subject Subject { get; set; } = null!;
}
