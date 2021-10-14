using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Compensation
    {
        public Guid id { get; set; }
        public Employee employee { get; set; }
        public string salary { get; set; }
        public string effectiveDate { get; set; }
    }
}
