using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.DTOs
{
    public class GetSalaryChangesDTO
    {
        public string? EmployeeFirstAndLastName { get; set; }
        public string? JobPosition { get; set; }
        public List<SalaryChanges>? SalaryChanges { get; set; }

        public List<GetSalaryChangesResponse> convertToResponse()
        {
            var SCsResponse = new List<GetSalaryChangesResponse>();
            foreach(SalaryChanges sc in SalaryChanges)
            {
                GetSalaryChangesResponse scResponse = new GetSalaryChangesResponse(){
                    EmployeeFirstAndLastName = this.EmployeeFirstAndLastName,
                    JobPosition = this.JobPosition,
                    SalaryChanges = sc
                };
                SCsResponse.Add(scResponse);
            }

            return SCsResponse;
        }
    }                                                                          
}