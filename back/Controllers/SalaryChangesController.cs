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
    public class SalaryChangesController : ControllerBase
    {
        private readonly ISalaryChangesService _salaryChangesService;

        public SalaryChangesController(ISalaryChangesService salaryChangesService)
        {
            _salaryChangesService = salaryChangesService;
        }

        [HttpGet]
        [EnableCors]
        public async Task<ActionResult<ServiceResponse<List<GetSalaryChangesResponse>>>> Get()
        {
            return Ok(await _salaryChangesService.GetAllSalaryChanges());
        }
    }
}