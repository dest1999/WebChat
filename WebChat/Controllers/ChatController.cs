using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class ChatController : Controller
    {
        private readonly ILogger<ChatController> _logger;
        private readonly IRepository<UserMessage> messagesRepository;
        private readonly ChatCore chatCore;

        public ChatController(ILogger<ChatController> logger, IRepository<UserMessage> MessagesRepository, ChatCore ChatCore)
        {
            _logger = logger;
            messagesRepository = MessagesRepository;
            chatCore = ChatCore;
        }

        public IActionResult Index()
        {
            var messages = chatCore.GetMessages();
            return View(messages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void CreateNewMessage(UserMessageDTO inputObj)
        {
            if(ModelState.IsValid)
            {
                var message = UserMessage.Create(inputObj);
                messagesRepository.Create(message);
                _logger.Log(LogLevel.Information, "message from UserId={userId}", message.CreatedByUserId);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}