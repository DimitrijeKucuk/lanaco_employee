using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.DTOs
{
    public class GetSalaryChangesResponse
    {
        public string? EmployeeFirstAndLastName { get; set; }
        public string? JobPosition { get; set; }
        public SalaryChanges? SalaryChanges { get; set; }
    }                                                                          
}