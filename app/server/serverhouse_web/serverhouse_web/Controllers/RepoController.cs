using System;
using System.Linq;
using serverhouse_web.Models.PropertyValue;
using serverhouse_web.Models.SHObject;
using SimpleJson;

namespace serverhouse_web.Controllers {
    public class RepoController : Controller {
        private const int OBJECTS_PER_PAGE = 10;

        private readonly SHObjectRepository repo;

        public RepoController() {
            repo = new SHObjectRepository();
        }

        public ActionResult Index(int page = 1) {
            ViewBag.page = page;
            ViewBag.nextPageAvailable = repo.getObjects(page + 1, OBJECTS_PER_PAGE).Count() > 0;
            var objects = repo.getObjects(page, OBJECTS_PER_PAGE);

            /*SHObject obj = objects[0];
            obj.set("text", new TextPropertyValue("hello"));
            repo.AddVersion(obj);*/

            //MembershipUser user = Membership.GetUser(User.Identity.Name).

            return View(objects);
        }

        public ActionResult View(long id) {
            var obj = repo.getObjectById(id);
            if (obj != null) {
                return View(obj);
            }

            return HttpNotFound();
        }

        public ActionResult Add() {
            var obj = new SHObject();
            obj = repo.AddVersion(obj);
            return RedirectToAction("edit", new {obj.id});
        }

        public ActionResult Edit(long id = -1) {
            if (id != -1) {
                var obj = repo.getObjectById(id);
                if (obj != null) {
                    return View("Edit", obj);
                }
            }

            return HttpNotFound();
        }

        [HttpPost]
        public string Edit() {
            try {
                var id = long.Parse(RouteData.Values["id"].ToString());

                SHObject obj;
                if ((obj = repo.getObjectById(id)) != null) {
                    string jsonProperties = Request.Form["properties"];
                    var properties = (JsonObject) SimpleJson.SimpleJson.DeserializeObject(jsonProperties);

                    var oldPropsJson = obj.properties.ToJson();
                    obj.properties.Clear();

                    foreach (var prop in properties) {
                        obj.set(prop.Key, PropertyValue.constructPropertyValue((JsonObject) prop.Value));
                    }

                    if (oldPropsJson != obj.properties.ToJson()) {
                        repo.AddVersion(obj);
                    }

                    return "success";
                }
            }
            catch (Exception ex) {
                return "error " + ex;
            }

            return "error";
        }

        public string Undo(long id) {
            try {
                SHObject obj;
                if ((obj = repo.getObjectById(id)) != null) {
                    if (repo.versionBack(id)) {
                        return "success";
                    }

                    return "no_versions_before";
                }
            }
            catch (Exception ex) {}

            return "error";
        }

        public string Redo(long id) {
            try {
                SHObject obj;
                if ((obj = repo.getObjectById(id)) != null) {
                    if (repo.versionForward(id)) {
                        return "success";
                    }

                    return "no_versions_after";
                }
            }
            catch (Exception ex) {}

            return "error";
        }

        public ActionResult Delete(long id) {
            SHObject obj;
            if ((obj = repo.getObjectById(id)) != null) {
                repo.Delete(obj);
            }

            return RedirectToAction("index", "repo");
        }

        public string getAllPossibleNames(string q = "") {
            return repo.getPropertyNames(q).ToJson();
        }
    }
}