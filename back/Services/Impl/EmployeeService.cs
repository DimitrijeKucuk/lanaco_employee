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

        public async Task<ServiceResponse<List<GetEmployeeWithPossiblePositions>>> GetPossiblePositions()
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeWithPossiblePositions>>();
            var dbEmployees = await _context.Employee.Include(e => e.PossibleEmployeePosition).ToListAsync();
            var dbPositions = await _context.JobPosition.ToListAsync();

            var ewpps = new List<GetEmployeeWithPossiblePositions>();
            foreach(Employee e in dbEmployees)
            {
                List<JobPosition> tmp = new List<JobPosition>(dbPositions);
                tmp.RemoveAll(job => e.PossibleEmployeePosition.Contains(job));

                var ewpp = new GetEmployeeWithPossiblePositions(){
                    EmployeeId = e.Id,
                    EmployeeFirstAndLastName = e.FirstName + " " + e.LastName,
                    CurrentPossibleJobPositions = e.PossibleEmployeePosition,
                    JobPositions = tmp
                };
                ewpps.Add(ewpp);
            }

            serviceResponse.Data = ewpps;
            return serviceResponse;
        }

        public async Task UpdateEmployeePossiblePositionAsync(UpdateEployeePossiblePositions updateEployeePossiblePositions)
        {
            var employee = await _context.Employee.Include(e => e.PossibleEmployeePosition).FirstOrDefaultAsync(e => e.Id == updateEployeePossiblePositions.id);
            employee.PossibleEmployeePosition.Add(updateEployeePossiblePositions.JobPosition);
            await _context.SaveChangesAsync();
        }
        
        public async Task RemoveEmployeePossiblePositionAsync(UpdateEployeePossiblePositions updateEployeePossiblePositions)
        {
            var employee = await _context.Employee.Include(e => e.PossibleEmployeePosition).FirstOrDefaultAsync(e => e.Id == updateEployeePossiblePositions.id);
            employee.PossibleEmployeePosition.Remove(employee.PossibleEmployeePosition.First(pos => pos.Id == updateEployeePossiblePositions.JobPosition.Id));
            await _context.SaveChangesAsync();
        }
    }
}