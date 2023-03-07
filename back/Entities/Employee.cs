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

         public List<SalaryChanges> GetSalaryChanges(){
            Salaries.Sort((a,b) => a.DateFrom.CompareTo(b.DateFrom));

            List<SalaryChanges> Changes = new List<SalaryChanges>();
            for(int i=0; i<Salaries.Count; i+=2)
            {
                if(i != Salaries.Count - 1)
                {
                    SalaryChanges sc = new SalaryChanges(){
                        date = Salaries[i].DateTo.ToString("dd.MM.yyyy"),
                        previousSalary = Salaries[i].Amount,
                        newSalary = Salaries[i + 1].Amount
                    };
                    Changes.Add(sc);
                }
            }

            return Changes;
         }

    }
}