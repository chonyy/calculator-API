using Calculator_API_ASP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator_API_ASP.Utils
{
    public class LogUtils : IUtils
    {
        public int AddToLog(string UserName, double Num1, double Num2, string OP)
        {
            using (var context = new TestingContext())
            {
                var emp = context.Employee.Where(emp => emp.EmpName == UserName).FirstOrDefault();

                //new employee, add to employee table
                if (emp == null)
                {
                    var newEmp = new Employee { EmpName = UserName };
                    context.Employee.Add(newEmp);
                    context.SaveChanges();
                }

                emp = context.Employee.Where(emp => emp.EmpName == UserName).FirstOrDefault();
                var log = new Log
                {
                    Num1 = Num1,
                    Num2 = Num2,
                    Op = OP
                };
                emp.Log.Add(log);
                context.SaveChanges();

                return emp.Id;
            }
        }

        public async Task<Log> AddToLogAsync(int UserID, string UserName, double Num1, double Num2, string OP)
        {
            using (var context = new TestingContext())
            {
                var emp = await context.Employee.Where(emp => emp.EmpName == UserName).FirstOrDefaultAsync();

                // new employee, add to employee table
                if (emp == null)
                {
                    await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT dbo.Employee ON insert into Employee (Id, EmpName) values ({UserID}, '{UserName}') SET IDENTITY_INSERT dbo.Employee OFF");
                }

                emp = await context.Employee.Where(emp => emp.EmpName == UserName).FirstOrDefaultAsync();
                var log = new Log
                {
                    Num1 = Num1,
                    Num2 = Num2,
                    Op = OP
                };
                emp.Log.Add(log);
                await context.SaveChangesAsync();

                return log;
            }
        }
    }
}
