using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebChat;

public class User
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле не должно быть пустым")]
    [Display(Name ="Имя пользователя")]
    [StringLength(10)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Поле не должно быть пустым")]
    [Display(Name ="Логин")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Поле не должно быть пустым")]
    [DataType(DataType.Password)]
    [Display(Name ="Пароль")]
    public string Password { get; set; }
}
