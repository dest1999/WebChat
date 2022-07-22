using Microsoft.AspNetCore.Mvc;

namespace WebChat.Controllers
{
    public class NewMessageFormViewComponent : ViewComponent
    {
        private readonly ChatCore chatCore;

        public NewMessageFormViewComponent(ChatCore ChatCore )
        {
            chatCore = ChatCore;
        }

        public IViewComponentResult Invoke()
        {
            var messagesDTO = new UserMessageDTO()
            {
                UsersListItems = chatCore.GetUsersListToChatView()
            };

            return View("PartialNewMessage", messagesDTO);
        }
    }
}
