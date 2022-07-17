using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebChat.Controllers
{
    public class NewMessageFormViewComponent : ViewComponent
    {
        private readonly IUserRepository<User> userRepository;

        public NewMessageFormViewComponent(IUserRepository<User> UserRepository)
        {
            userRepository = UserRepository;
        }

        public IViewComponentResult Invoke()
        {
            var tmp = new SelectList(
                    userRepository.GetAll(),
                    nameof(WebChat.User.Id),
                    nameof(WebChat.User.UserName));

            var messagesDTO = new UserMessageDTO()
            {
                UsersListItems = tmp
            };
            
            return View("PartialNewMessage", messagesDTO);
        }
    }
}
