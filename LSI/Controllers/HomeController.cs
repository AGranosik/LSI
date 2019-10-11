using LSI.Data.Context;
using System.Linq;
using System.Web.Mvc;

namespace LSI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(var context = new ExportDbContext())
            {
                var users = context.Users.ToList();
                var locals = context.Locals.ToList();
                var exports = context.Exports.ToList();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}