using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.DTOs
{
    public class SalaryChanges
    {
        public string? date { get; set; }
        public double previousSalary { get; set; }
        public double newSalary { get; set; }
    }
}