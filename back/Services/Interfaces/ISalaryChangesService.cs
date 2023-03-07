using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Services.Interfaces
{
    public interface ISalaryChangesService
    {
        Task<ServiceResponse<List<GetSalaryChangesResponse>>> GetAllSalaryChanges();
    }
}