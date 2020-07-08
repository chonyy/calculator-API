using System;
using System.Collections.Generic;

namespace Log_API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Log = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string EmpName { get; set; }

        public virtual ICollection<Log> Log { get; set; }
    }
}
