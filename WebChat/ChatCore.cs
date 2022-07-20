using System.Text;

namespace WebChat;

public class ChatCore
{
    private readonly IRepository<User> userRepo;
    private readonly IRepository<UserMessage> messageRepo;

    public ChatCore(IRepository<User> UserRepo, IRepository<UserMessage> MessageRepo)
    {
        userRepo = UserRepo;
        messageRepo = MessageRepo;
    }

    public IEnumerable<string> GetMessages()
    {
        var messages = messageRepo.GetAll();
        var outMessages = new List<string>();
        var str = new StringBuilder();
        foreach (var message in messages)
        {
            str.Append(userRepo.Get(message.CreatedByUserId).UserName);
            str.Append(" (" + message.Created + "): ");
            str.Append(message.Message);
            outMessages.Add(str.ToString() );
            str.Clear();
        }

        return outMessages;
    }


}
