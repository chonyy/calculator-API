using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator_API_ASP.Models
{
    public class Calculation
    {
        public string UserName { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string OP { get; set; }
    }
}
