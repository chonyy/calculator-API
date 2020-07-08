using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calculator_API_ASP.Models;
using Calculator_API_ASP.Utils;

namespace Calculator_API_ASP.Controllers
{

    [Route("/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly TestingContext _context;

        public LogsController(TestingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetLog()
        {
            return await _context.Log.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Log>>> GetLog(int id)
        {
            var logs = await _context.Log.Where(log => log.UserId == id).ToListAsync();

            if (logs == null)
            {
                return NotFound();
            }

            return logs;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Log>> PutLog(int id, Log log)
        {
            // ID mismatch
            if (id != log.Id)
            {
                return BadRequest();
            } 
            // ID not found
            if(!(_context.Log.Any(l => l.Id == id)))
            {
                return NotFound();
            }

            // EmpID not found 
            var emp = _context.Employee.Where(e => e.Id == log.UserId).FirstOrDefault();
            if (emp == null)
            {
                return BadRequest();
            }

            _context.Entry(log).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return log;
        }

        [HttpPost]
        public async Task<ActionResult<LogRequest>> PostLog(LogRequest req)
        {
            var emp = await _context.Employee.Where(e => e.Id == req.UserId).FirstOrDefaultAsync();
            //if ID exists, but name different
            if (emp != null && emp.EmpName != req.UserName)
            {
                return BadRequest();
            }
            emp = await _context.Employee.Where(e => e.EmpName == req.UserName).FirstOrDefaultAsync();
            // if name exists, but ID different
            if (emp != null && emp.Id != req.UserId)
            {
                return BadRequest();
            }

            var utils = new LogUtils();
            var log = await utils.AddToLogAsync(req.UserId, req.UserName, req.Num1, req.Num2, req.Op);

            return req;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Log>> DeleteLog(int id)
        {
            var log = await _context.Log.FindAsync(id);
            if (log == null)
            {
                return NotFound();
            }

            _context.Log.Remove(log);
            await _context.SaveChangesAsync();

            return log;
        }
    }
}
