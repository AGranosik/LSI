using LSI.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Data.Models
{
    public class Local : BaseModel
    {
        public string Name { get; set; }
    }
}
