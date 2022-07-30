﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebChat;

public class User
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле не должно быть пустым")]
    [Display(Name ="Имя пользователя")]
    [StringLength(maximumLength: 25, MinimumLength = 1)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Поле не должно быть пустым")]
    [Display(Name ="Логин")]
    [StringLength(maximumLength: 25, MinimumLength = 1)]
    public string Login { get; set; }

    [Required(ErrorMessage = "Поле не должно быть пустым")]
    [Display(Name ="Пароль")]
    [DataType(DataType.Password)]
    [StringLength (maximumLength: 25, MinimumLength = 1)]
    public string Password { get; set; }
}
