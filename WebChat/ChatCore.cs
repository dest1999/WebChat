using Microsoft.AspNetCore.SignalR;
using System.Text;

namespace WebChat;

public class ChatCore
{
    private readonly IRepository<User> userRepo;
    private readonly IRepository<UserMessage> messageRepo;
    private readonly IHubContext<MessageSpreader> hubContext;
    private StringBuilder sb = new();

    public ChatCore(IRepository<User> UserRepo, IRepository<UserMessage> MessageRepo, IHubContext<MessageSpreader> HubContext)
    {
        userRepo = UserRepo;
        messageRepo = MessageRepo;
        hubContext = HubContext;
    }

    public IEnumerable<string> GetAllMessages()
    {
        var messages = messageRepo.GetAll();
        var outMessages = new List<string>(messages.Count());
        foreach (var message in messages)
        {
            outMessages.Add(GetMessage(message));
        }

        return outMessages;
    }

    public string GetMessage(UserMessage message)
    {
        sb.Clear();
        sb.Append(userRepo.Get(message.CreatedByUserId).UserName);
        sb.Append(" (" + message.Created + "): ");
        sb.Append(message.Message + "\n");
        
        return sb.ToString();
    }

    public void RecievedNewMessage(UserMessageDTO newMessageDTO)
    {
        var message = UserMessage.Create(newMessageDTO);
        DistributeMessage(GetMessage(message));
        messageRepo.Create(message);
    }

    private void DistributeMessage(string message)
    {
        hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }

}
