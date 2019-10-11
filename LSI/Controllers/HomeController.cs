using LSI.BusinessLogic.Services.Interfaces;
using LSI.Common.Repositories;
using LSI.Data.Context;
using LSI.Data.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LSI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExportService _service;

        public HomeController()
        {

        }
        public HomeController(IExportService service)
        {
            _service = service;
        }
        public async Task<ActionResult> Index()
        {
            var list = await _service.GetAllListAsync();
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