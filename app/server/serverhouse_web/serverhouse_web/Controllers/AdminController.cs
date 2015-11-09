using System.Web.Security;

namespace serverhouse_web.Controllers {
    public class AdminController : Controller {
        //
        // GET: /Admin/

        public ActionResult Index() {
            var users = Membership.GetAllUsers();
            return View(users);
        }
    }
}