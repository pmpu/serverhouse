using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using serverhouse_web.Models.SHObject;

namespace serverhouse_web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            SHObjectRepository objRepo = new SHObjectRepository();
            SHObject obj = new SHObject();                        
            obj = objRepo.AddVersion(obj);

            obj.setProperty("asd", "sad");
            objRepo.AddVersion(obj);
            objRepo.AddVersion(obj);

            objRepo.versionBack(obj.id);
            objRepo.versionBack(obj.id);
            objRepo.AddVersion(obj);
 

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
