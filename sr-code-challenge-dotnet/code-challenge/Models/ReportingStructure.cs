using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class ReportingStructure
    {

        public ReportingStructure(Employee _employee)
        {
            employee = _employee;
        }



        public Employee employee { get; set; }
        public int numberOfReports { 
            get
            {
                if (employee.DirectReports == null)
                {
                    return 0;
                }

                int reports = 0;
                for (int i = 0; i < employee.DirectReports.Count; i++)
                {
                    reports += 1 + new ReportingStructure(employee.DirectReports[i]).numberOfReports;
                }
                return reports;
            }
        }

    }
}
