using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebChat;

public class UserMessageDTO
{
    [ValidateNever]
    [Required(ErrorMessage = "Выберите пользователя")]
    [DisplayName("Пользователь:")]
    public SelectList? UsersListItems { get; set; }

    public int SelectedUserId { get; set; }

    [Required(AllowEmptyStrings = false)]
    [DisplayName("Сообщение")]
    public string Message { get; set; }
}
