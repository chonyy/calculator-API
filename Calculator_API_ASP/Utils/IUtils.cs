using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator_API_ASP.Utils
{
    public interface IUtils
    {
        public int AddToLog(string UserName, double Num1, double Num2, string OP);
    }
}
