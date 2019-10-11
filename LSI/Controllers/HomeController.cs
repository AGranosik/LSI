using LSI.BusinessLogic.Filters;
using LSI.BusinessLogic.Services.Interfaces;
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
            return View();
        }
    }
}