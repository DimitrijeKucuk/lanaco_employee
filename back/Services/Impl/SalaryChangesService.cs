global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using back.Services.Interfaces;

namespace back.Services.Impl.EmployeeService
{
    public class SalaryChangesService : ISalaryChangesService
    {
        private readonly IMapper _mapper;
        private readonly DataContex _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SalaryChangesService(IMapper mapper, DataContex context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetSalaryChangesResponse>>> GetAllSalaryChanges()
        {
            var serviceResponse = new ServiceResponse<List<GetSalaryChangesResponse>>();
            var dbEmployees = await _context.Employee.Include(e => e.EmployeePositions).ThenInclude(p => p.JobPosition).Include(e => e.Salaries).ToListAsync();
            var SCs = dbEmployees.Select(c => _mapper.Map<GetSalaryChangesDTO>(c)).ToList();
            var SCsResponse = new List<GetSalaryChangesResponse>();
            foreach(GetSalaryChangesDTO scsDTO in SCs)
            {
                SCsResponse.AddRange(scsDTO.convertToResponse());
            }
            SCsResponse.Sort((a,b) => a.SalaryChanges.date.CompareTo(b.SalaryChanges.date));
            serviceResponse.Data = SCsResponse;
            return serviceResponse;
        }

    }
}