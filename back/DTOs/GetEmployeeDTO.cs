using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.DTOs
{
    public class GetEmployeeDTO
    {
        public string? FirstAndLastName { get; set; }
        public string? JobPosition { get; set; }
        public string? JobPositionPeriod { get; set; }
        public string? BossFirstAndLastName { get; set; }
        public double Salary { get; set; }
        public double ActiveBonus { get; set; }
        public double ActiveDeducation { get; set; }
    }
}