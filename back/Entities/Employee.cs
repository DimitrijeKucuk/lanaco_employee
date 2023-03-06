using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int VacationDays { get; set; }

        public Employee? Boss { get; set; }

        public List<EmployeePosition>? EmployeePositions { get; set; }

        public List<Salary>? Salaries { get; set; }

        public List<Bonus>? Bonuses { get; set; }

        public List<Deducation>? Deducations { get; set; }

         public List<JobPosition>? PossibleEmployeePosition { get; set; }

    }
}