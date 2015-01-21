using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;

using serverhouse_web.Models.SHObject;
using serverhouse_web.Models.PropertyValue;

using SimpleJson;

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

            /*SHObject obj = objects[0];
            obj.set("text", new TextPropertyValue("hello"));
            repo.AddVersion(obj);*/
            
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
        public string Edit()
        {

            try
            {
                long id = long.Parse(RouteData.Values["id"].ToString());

                SHObject obj;
                if ((obj = repo.getObjectById(id)) != null)
                {
                    string jsonProperties = Request.Form["properties"];
                    JsonObject properties = (JsonObject)SimpleJson.SimpleJson.DeserializeObject(jsonProperties);
                    
                    foreach (var prop in properties)
                    {
                        obj.set(prop.Key, PropertyValue.constructPropertyValue((JsonObject)prop.Value)); 
                    }
                    repo.AddVersion(obj);

                    return "success";
                }
            }
            catch (Exception ex) { }

            return "error";
        }

        public ActionResult Delete(long id) { 
            SHObject obj;
            if ((obj = repo.getObjectById(id)) != null)
            {
                repo.Delete(obj);
            }

            return RedirectToAction("index", "repo");
        }

        public string getAllPossibleNames(string q = "") {
            return repo.getPropertyNames(q).ToJson();
        }

    }
}
