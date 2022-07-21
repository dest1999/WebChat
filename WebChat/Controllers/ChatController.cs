using Microsoft.AspNetCore.Mvc;

namespace WebChat.Controllers
{
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;
        private readonly ChatCore chatCore;

        public ChatController(ILogger<ChatController> logger, ChatCore ChatCore)
        {
            _logger = logger;
            chatCore = ChatCore;
        }

        public IActionResult Index()
        {
            var messages = chatCore.GetAllMessages();
            return View(messages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void CreateNewMessage(UserMessageDTO inputObj)
        {
            if(ModelState.IsValid)
            {
                chatCore.RecievedNewMessage(inputObj);
                _logger.Log(LogLevel.Information, "recieved message from UserId={userId}", inputObj.SelectedUserId);
            }
        }
    }
}