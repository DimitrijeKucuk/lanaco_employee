using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Entities
{
    public class EmployeePosition
    {
        public int Id { get; set; }

        public Employee? Employee { get; set; }

        public JobPosition? JobPosition { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string getPeriod(){
            return DateFrom + " " + DateTo;
        }
    }
}