using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator_API_ASP.Models;
using Calculator_API_ASP.Logic;
using Microsoft.AspNetCore.Mvc;
using Calculate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calculator_API_ASP.Controllers 
    {

    [Route("api/[controller]")]
    [ApiController]
    public class FormulaController : ControllerBase 
        {

        // POST api/<FormulaController>
        [HttpPost]
        public ActionResult Post(Formula val) 
            {
            if (!ModelState.IsValid) {
                return BadRequest("Invalid number format!");
            }
            if (!(val.OP == "+" || val.OP == "-" || val.OP == "*" || val.OP == "/")) 
                return BadRequest("Invalid Operator!");

            var log = new CalculateLogic();
            var ans = log.DoCalculation(val.Num1, val.Num2, val.OP);

            return Ok(ans);
        }
    }
}
