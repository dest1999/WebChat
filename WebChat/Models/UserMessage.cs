using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebChat;

public class UserMessage
{
    public int Id { get; set; }

    public int CreatedByUserId { get; private set; }

    public string Message { get; private set; }

    public DateTime Created { get; private set; }

    public UserMessage()
    {

    }
    
    private UserMessage(UserMessageDTO userMessageDTO)
    {
        CreatedByUserId = userMessageDTO.SelectedUserId;
        Message = userMessageDTO.Message;
        Created = DateTime.Now;
    }
    
    public static UserMessage Create(UserMessageDTO userMessageDTO)
    {
        return new UserMessage(userMessageDTO);
    }
}
