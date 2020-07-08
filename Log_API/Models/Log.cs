using System;
using System.Collections.Generic;

namespace Log_API.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public double? Num1 { get; set; }
        public double? Num2 { get; set; }
        public string Op { get; set; }

        public virtual Employee User { get; set; }
    }
}
