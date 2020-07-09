using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator_API_ASP.Utils
{
    public class LogService
    {
        private readonly IUtils _logUtils;

        public LogService(IUtils logUtils)
        {
            _logUtils = logUtils;
        }

        public int DoService(string UserName, double Num1, double Num2, string OP)
        {
            return _logUtils.AddToLog(UserName, Num1, Num2, OP);  
        }
    }
}
