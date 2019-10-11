using LSI.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.BusinessLogic.Filters
{
    public class ExportFilter : Pagination
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? LocalId { get; set; }
    }
}
