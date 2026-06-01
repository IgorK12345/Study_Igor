using System.ComponentModel.DataAnnotations;

namespace Logic.DTOs.University;

public class UniversityUpdateDto
{
    [Required(ErrorMessage = "Id вуза обязательно")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Название вуза обязательно")]
    [MaxLength(300, ErrorMessage = "Название вуза не должно превышать 300 символов")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Адрес вуза обязателен")]
    [MaxLength(500, ErrorMessage = "Адрес не должен превышать 500 символов")]
    public string Address { get; set; } = string.Empty;
}
