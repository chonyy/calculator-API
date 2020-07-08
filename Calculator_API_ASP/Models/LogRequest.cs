using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator_API_ASP.Models
{
    public class LogRequest
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string Op { get; set; }
        public virtual Employee User { get; set; }
    }
}
