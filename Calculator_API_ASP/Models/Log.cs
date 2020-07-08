using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Calculator_API_ASP.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string Op { get; set; }
        [JsonIgnore]
        public virtual Employee User { get; set; }
    }
}
