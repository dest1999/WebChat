using Microsoft.AspNetCore.Mvc;

namespace WebChat.Controllers
{
    public class UserCreateFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View("PartialCreate", new User());
        }
    }
}
