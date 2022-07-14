using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebChat;

public class User
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Required]
    [Display(Name ="Имя пользователя")]
    [StringLength(10)]
    public string UserName { get; set; }
    
    [Required]
    [Display(Name ="Логин")]
    public string Login { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Display(Name ="Пароль")]
    public string Password { get; set; }
}
