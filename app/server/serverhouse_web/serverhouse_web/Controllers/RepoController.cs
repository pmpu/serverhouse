﻿using System;
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
            if (objects.Count() > 0) {
                return View(objects);
            }

            return HttpNotFound();
            
        }

        public string asyncObjectList(int page = 1) {
            List<SHObject> all = repo.getObjects(page, OBJECTS_PER_PAGE);
            return all.ToJson(new MongoDB.Bson.IO.JsonWriterSettings { 
                OutputMode = MongoDB.Bson.IO.JsonOutputMode.Strict 
            });
        }

        public ActionResult View(long id) {
            SHObject obj = repo.getObjectById(id);
            if (obj != null)
            {
                return View(obj);
            }else {
                return HttpNotFound();
            }
        }

    }
}
