using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MongoDB.Bson;

using serverhouse_web.Models.SHObject;

namespace serverhouse_web.Controllers
{
    public class RepoController : Controller
    {

        private const int OBJECTS_PER_PAGE = 10;

        SHObjectRepository repo;

        public RepoController() {
            repo = new SHObjectRepository();
        }

        public ActionResult Index(int page = 1)
        {
            ViewBag.page = page;
            ViewBag.nextPageAvailable = repo.getObjects(page + 1, OBJECTS_PER_PAGE).Count() > 0;
            List<SHObject> objects = repo.getObjects(page, OBJECTS_PER_PAGE);
            
            return View(objects);
        }

        public ActionResult View(long id) {
            SHObject obj = repo.getObjectById(id);
            if (obj != null){
                return View(obj);
            }

            return HttpNotFound();            
        }

        public ActionResult Add() {            
            SHObject obj = new SHObject();                        
            obj = repo.AddVersion(obj);
            return View("Edit", obj);
        }
        

        public ActionResult Edit(long id = -1)
        {
            if(id != -1){
                SHObject obj = repo.getObjectById(id);
                if (obj != null) {
                    return View("Edit", obj);
                }
            }

            return HttpNotFound();            
        }

        [HttpPost]
        public ActionResult Edit()
        {

            try
            {
                long id = long.Parse(RouteData.Values["id"].ToString());

                SHObject obj;
                if ((obj = repo.getObjectById(id)) != null)
                {
                    foreach (string key in Request.Form)
                    {
                        string value = Request.Form[key];
                        obj.setProperty(key, value);
                    }


                    repo.AddVersion(obj);

                    return RedirectToAction("view", "repo", new { id = id });
                }
            }
            catch (Exception ex) { }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Delete(long id) { 
            SHObject obj;
            if ((obj = repo.getObjectById(id)) != null)
            {
                repo.Delete(obj);
            }

            return RedirectToAction("index", "repo");
        }

    }
}
