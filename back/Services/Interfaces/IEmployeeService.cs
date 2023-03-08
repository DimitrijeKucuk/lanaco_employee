using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<GetEmployeeDTO>>> GetAllEmployee();

        Task<ServiceResponse<List<GetEmployeeWithPossiblePositions>>> GetPossiblePositions();

        Task UpdateEmployeePossiblePositionAsync(UpdateEployeePossiblePositions updateEployeePossiblePositions);

        Task RemoveEmployeePossiblePositionAsync(UpdateEployeePossiblePositions updateEployeePossiblePositions);
    }
}