using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDTO>>>> Get()
        {
            return Ok(await _employeeService.GetAllEmployee());
        }

        [HttpGet]
        [Route("PossibleJobPositions")]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDTO>>>> GetPossiblePositions()
        {
            return Ok(await _employeeService.GetPossiblePositions());
        }

         [HttpPut]
         [Route("PossibleJobPositions")]
        public async void UpdateCharacter(UpdateEployeePossiblePositions updatedEmployeePossiblePosition)
        {
            var response = await _employeeService.UpdateEmployeePossiblePosition(updatedEmployeePossiblePosition);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}