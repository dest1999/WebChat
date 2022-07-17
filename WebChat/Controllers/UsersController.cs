using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebChat.Controllers
{
    public class UsersController : Controller
    {
        private IRepository<User> _userRepository;

        public UsersController(IRepository<User> userRepository)
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
            if (ModelState.IsValid)
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
