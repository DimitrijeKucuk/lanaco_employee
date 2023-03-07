using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.DTOs
{
    public class GetEmployeeWithPossiblePositions
    {
        public int EmployeeId { get; set; }
        public string? EmployeeFirstAndLastName { get; set; }
        public List<JobPosition>? CurrentPossibleJobPositions { get; set; }
        public List<JobPosition>? JobPositions { get; set; }
    }
}