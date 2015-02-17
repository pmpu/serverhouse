using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

using serverhouse_web.Models.SHObject;

namespace serverhouse_web.Controllers
{
    public class SearchController : Controller
    {
        SHObjectRepository repo;

        private const int OBJECTS_PER_PAGE = 10;


        public SearchController() { 
            repo = new SHObjectRepository();
        }

        [ValidateInput(false)]
        public ActionResult Index(string q = "", int page = 1){
            var results = repo.findObjects(q, page, OBJECTS_PER_PAGE);
            ViewBag.query = q;
            ViewBag.page = page;
            ViewBag.nextPageAvailable = repo.getObjects(page + 1, OBJECTS_PER_PAGE).Count() > 0;

            return View(results);            
        }

        [ValidateInput(false)]
        public ActionResult Suggestions(string q = "", int page = 1) { 
            var results = repo.findObjects(q, page, OBJECTS_PER_PAGE);
            return PartialView(results);
        }

    }
}
