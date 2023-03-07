using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.DTOs
{
    public class GetEmployeeWithPossiblePositions
    {
        public Employee? Employee { get; set; }
        public List<JobPosition>? JobPositions { get; set; }
    }
}