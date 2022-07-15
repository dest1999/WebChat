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


        // GET: UsersController
        public IActionResult Index()
        {
            var users = _userRepository.GetAll();
            return View(users);
            //return View((users, new User()));
        }

        public PartialViewResult SendUserToForm()
        {
            return PartialView(new User());
        }


        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User inputObj)
        {
            User tmp = inputObj;


            try
            {
                //var user = new User
                //{
                //    //UserName = collection["Item2.UserName"],
                //    Login = collection["Item2.Login"],
                //    Password = collection["Item2.Login"]
                //};

                _userRepository.Create(tmp);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest("Невозможно создать пользователя");
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
