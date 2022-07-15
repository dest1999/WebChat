using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebChat.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository<User> _userRepository;

        public UsersController(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = _userRepository.GetAll();
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User inputObj)
        {
            if (inputObj is User)
            {
                User user = inputObj;
                user.Id = 0; // БД сама ставит индекс
                _userRepository.Create(user);
                return RedirectToAction(nameof(Index));

            }

            return BadRequest("Невозможно создать пользователя");
        }

    }
}
