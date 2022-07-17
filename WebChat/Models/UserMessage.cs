using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebChat;

public class UserMessage
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Выберите пользователя")]
    [DisplayName("Пользователь: ")]
    public User User { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Введите сообщение")]
    [DisplayName("Сообщение")]
    public string Message { get; set; }

    public DateTime Created { get; set; }
}
