using System.ComponentModel.DataAnnotations;

namespace Logic.DTOs.HeadTeacher;

public class HeadTeacherCreateDto
{
    [Required(ErrorMessage = "ФИО преподавателя обязательно")]
    [MaxLength(300, ErrorMessage = "ФИО не должно превышать 300 символов")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Стаж работы обязателен")]
    [Range(0, 80, ErrorMessage = "Стаж должен быть от 0 до 80 лет")]
    public int ExperienceYears { get; set; }

    [Required(ErrorMessage = "Учёная степень обязательна")]
    [MaxLength(100, ErrorMessage = "Учёная степень не должна превышать 100 символов")]
    public string Degree { get; set; } = string.Empty;

    [Required(ErrorMessage = "Id предмета/кафедры обязательно")]
    public int SubjectId { get; set; }
}
