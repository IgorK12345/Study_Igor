using System.ComponentModel.DataAnnotations;

namespace Logic.DTOs.University;

public class UniversityCreateDto
{
    [Required(ErrorMessage = "Название вуза обязательно")]
    [MaxLength(300, ErrorMessage = "Название вуза не должно превышать 300 символов")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Адрес вуза обязателен")]
    [MaxLength(500, ErrorMessage = "Адрес не должен превышать 500 символов")]
    public string Address { get; set; } = string.Empty;
}
