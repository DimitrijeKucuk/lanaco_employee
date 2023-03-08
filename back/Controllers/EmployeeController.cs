using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDTO>>>> Get()
        {
            return Ok(await _employeeService.GetAllEmployee());
        }

        [HttpGet]
        [Route("PossibleJobPositions")]
        [EnableCors]
        public async Task<ActionResult<ServiceResponse<List<GetEmployeeDTO>>>> GetPossiblePositions()
        {
            return Ok(await _employeeService.GetPossiblePositions());
        }

         [HttpPut]
         [Route("PossibleJobPositions")]
        public async Task<ActionResult<string>> Update(UpdateEployeePossiblePositions updatedEmployeePossiblePosition)
        {
            await _employeeService.UpdateEmployeePossiblePositionAsync(updatedEmployeePossiblePosition);
            return Ok();
        }

        [HttpPut]
        [Route("PossibleJobPositionsDelete")]
        public async Task<ActionResult<string>> Delete(UpdateEployeePossiblePositions updatedEmployeePossiblePosition)
        {
            await _employeeService.RemoveEmployeePossiblePositionAsync(updatedEmployeePossiblePosition);
            return Ok();
        }
    }
}