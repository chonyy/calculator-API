using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculate;

namespace Calculator_API_ASP.Logic {
    public class CalculateLogic {
        public double DoCalculation(double num1, double num2, string op) {
            ICalculator cal = null;
            switch (op) {
                case "+":
                    cal = new Addition();
                    break;
                case "-":
                    cal = new Subtraction();
                    break;
                case "*":
                    cal = new Multiplication();
                    break;
                case "/":
                    cal = new Division();
                    break;
            }
            return (cal.Calculate(num1, num2));
        }
    }
}
