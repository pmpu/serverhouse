using System.Linq;
using serverhouse_web.Models.SHObject;

namespace serverhouse_web.Controllers {
    public class SearchController : Controller {
        private const int OBJECTS_PER_PAGE = 10;
        private readonly SHObjectRepository repo;

        public SearchController() {
            repo = new SHObjectRepository();
        }

        [ValidateInput(false)]
        public ActionResult Index(string q = "", int page = 1, int per_page = OBJECTS_PER_PAGE) {
            var results = repo.findObjects(q, page, per_page);
            ViewBag.query = q;
            ViewBag.page = page;
            ViewBag.nextPageAvailable = repo.getObjects(page + 1, per_page).Count() > 0;

            return View(results);
        }

        [ValidateInput(false)]
        public ActionResult Suggestions(string q = "", int page = 1, int per_page = OBJECTS_PER_PAGE) {
            var results = repo.findObjects(q, page, per_page);
            return PartialView(results);
        }
    }
}