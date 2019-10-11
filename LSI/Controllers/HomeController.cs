﻿using LSI.BusinessLogic.Filters;
using LSI.BusinessLogic.Services.Interfaces;
using LSI.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LSI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExportService _exportService;
        private readonly ILocalService _localService;

        public HomeController()
        {

        }
        public HomeController(IExportService service, ILocalService localService)
        {
            _exportService = service;
            _localService = localService;
        }

        public async Task<ActionResult> Index(ExportFilter filter)
        {
            var tuple = await _exportService.FilteredListAsync(filter);
            var localList = await _localService.GetAllListAsync();
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