using LSI.Application.Repositories.Interfaces;
using LSI.BusinessLogic.Dtos;
using LSI.BusinessLogic.Filters;
using LSI.BusinessLogic.Services.Interfaces;
using LSI.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LSI.Controllers
{
    public class HomeController : BaseActionDtoController<ExportDto>
    {
        private readonly IExportService _exportService;
        private readonly ILocalService _localService;
        public HomeController(IExportService service, ILocalService localService, ILogger logger) : base(logger)
        {
            _exportService = service;
            _localService = localService;
        }

        public async Task<ActionResult> Index(ExportFilter filter)
        {

            var tuple = await RunTupleResultAsync(() =>  _exportService.FilteredListAsync(filter));
            var localList = await RunListActionResultAsync<LocalDto>(() => _localService.GetAllListAsync());
            var vm = new ExportViewModel
            {
                Exports = tuple.Item1,
                NumberOfModels = tuple.Item2,
                Models = localList.Select(l => new SelectListItem { Value = l.ID.ToString(), Text = l.Name}).ToList()
            };
            //var vm 
            return View(vm);
        }


    }
}