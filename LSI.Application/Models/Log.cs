using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Data.Models
{
    public class Log
    {
        public Log(Exception ex)
        {
            Message = ex.Message;
            Time = DateTime.Now;
            Type = ex.GetType().Name;
            Method = ex.TargetSite.ToString();
            Object = ex.Source;
        }

        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        public string Object { get; set; }
    }
}
