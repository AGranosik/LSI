using LSI.BusinessLogic.Services.Interfaces;
using LSI.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.BusinessLogic.Dtos
{
    public class ExportDto : BaseDto
    {

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public int UserId { get; set; }
        public virtual UserDto User { get; set; }
        public int LocalId { get; set; }
        public virtual LocalDto Local { get; set; }
    }
}
