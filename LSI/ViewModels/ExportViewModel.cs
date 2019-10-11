using LSI.BusinessLogic.Dtos;
using LSI.BusinessLogic.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LSI.ViewModels
{
    public class ExportViewModel : ExportFilter
    {
        public int? SelectedId { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<ExportDto> Exports { get; set; }
    }
}
