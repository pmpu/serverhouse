using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestServer.Models;

namespace TestServer.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        User U = new User();
        
        public ActionResult Index()
        {
            ViewBag.Users = U;
            return View();
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            ViewBag.UserId = id;
            return View();
        }
        [HttpPost]
        public string Show(User user)//вызывается при заполнении формы
        {
            return user.Email + " " + user.Password;
        }

    }
}
