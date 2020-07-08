using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator_API_ASP.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Log = new HashSet<Log>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EmpName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Log> Log { get; set; }
    }
}
