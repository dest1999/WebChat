using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebChat.Controllers
{
    public class UsersController : Controller
    {
        private IRepository<User> userRepository;

        public UsersController(IRepository<User> UserRepository)
        {
            userRepository = UserRepository;
        }

        public IActionResult Index()
        {
            var users = userRepository.GetAll();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User inputObj)
        {
            if (ModelState.IsValid)
            {
                User user = inputObj;
                user.Id = 0; // БД сама ставит индекс
                try
                {
                    userRepository.Create(user);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    
                }
            }
            return BadRequest("Невозможно создать пользователя");
        }

    }
}
