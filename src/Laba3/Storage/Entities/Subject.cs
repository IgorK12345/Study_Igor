namespace Storage.Entities;

public class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int UniversityId { get; set; }

    public University University { get; set; } = null!;

    public HeadTeacher? HeadTeacher { get; set; }
}
