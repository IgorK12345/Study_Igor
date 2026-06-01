using System.ComponentModel.DataAnnotations;

namespace Logic.DTOs.Subject;

public class SubjectUpdateDto
{
    [Required(ErrorMessage = "Id предмета обязательно")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Название предмета обязательно")]
    [MaxLength(200, ErrorMessage = "Название предмета не должно превышать 200 символов")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000, ErrorMessage = "Описание не должно превышать 1000 символов")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Id вуза обязательно")]
    public int UniversityId { get; set; }
}
