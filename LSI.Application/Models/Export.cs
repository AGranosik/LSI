﻿using LSI.Common.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSI.Data.Models
{
    public class Export : BaseModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int LocalId { get; set; }
        public virtual Local Local { get; set; }
    }
}
