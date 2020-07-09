using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator_API_ASP.Models;
using Calculator_API_ASP.Logic;
using Calculator_API_ASP.Utils;
using Microsoft.AspNetCore.Mvc;
using Calculate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calculator_API_ASP.Controllers 
    {

    [Route("/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase 
    {

        [HttpPost]
        public ActionResult Post(Calculation cal) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest("Invalid number format!");
            }
            if (!(cal.OP == "+" || cal.OP == "-" || cal.OP == "*" || cal.OP == "/")) 
                return BadRequest("Invalid Operator!");

            // add to log
            var logUtils = new LogUtils();
            var service = new LogService(logUtils);
            var UserID = service.DoService(cal.UserName, cal.Num1, cal.Num2, cal.OP);
            // calculate answer
            var logic = new CalculateLogic();
            var ans = logic.DoCalculation(cal.Num1, cal.Num2, cal.OP);

            //var res = new OkObjectResult(new { ans, UserID });
            return Ok(new { ans, UserID });
        }

    }
}
