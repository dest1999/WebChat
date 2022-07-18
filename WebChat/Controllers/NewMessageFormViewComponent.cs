using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebChat.Controllers
{
    public class NewMessageFormViewComponent : ViewComponent
    {
        private readonly IRepository<User> userRepository;

        public NewMessageFormViewComponent(IRepository<User> UserRepository)
        {
            userRepository = UserRepository;
        }

        public IViewComponentResult Invoke()
        {
            #region эту генерацию перенести в CoreLogic, инъекцию репозитория туда же
            var tmp = new SelectList(
                    userRepository.GetAll(),
                    nameof(WebChat.User.Id),
                    nameof(WebChat.User.UserName));

            var messagesDTO = new UserMessageDTO()
            {
                UsersListItems = tmp
            };
            #endregion
            return View("PartialNewMessage", messagesDTO);
        }
    }
}
