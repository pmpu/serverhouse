using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace serverhouse_web.Controllers
{
    public class AsyncPartialController : Controller
    {

        public ActionResult Edit(string part) {
            return PartialView("Edit", part);
        }

    }
}
