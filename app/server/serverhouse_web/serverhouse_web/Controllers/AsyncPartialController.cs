namespace serverhouse_web.Controllers {
    public class AsyncPartialController : Controller {
        public ActionResult Edit(string part) {
            return PartialView("Edit", part);
        }
    }
}