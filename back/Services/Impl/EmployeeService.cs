global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using back.Services.Interfaces;

namespace back.Services.Impl.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly DataContex _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeService(IMapper mapper, DataContex context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetEmployeeDTO>>> GetAllEmployee()
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDTO>>();
            var dbEmployees = await _context.Employee.Include(e => e.EmployeePositions).ThenInclude(p => p.JobPosition)
            .Include(e => e.Salaries).Include(e => e.Bonuses).Include(e => e.Deducations).ToListAsync();
            serviceResponse.Data = dbEmployees.Select(c => _mapper.Map<GetEmployeeDTO>(c)).ToList();
            return serviceResponse;
        }

    }
}