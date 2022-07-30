using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebChat.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> logger;
        private IRepository<User> userRepository;

        public UsersController(ILogger<UsersController> Logger, IRepository<User> UserRepository)
        {
            logger = Logger;
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
                    var userId = userRepository.Create(user);
                    logger.Log(LogLevel.Information, "created new user, Id={}, Name={} ", userId, user.UserName);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    logger.Log(LogLevel.Error, ex, "Can't create user Name={} ", user.UserName);
                }
            }
            return BadRequest("Невозможно создать пользователя");
        }

    }
}
