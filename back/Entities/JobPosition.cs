using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace back.Entities
{
    public class JobPosition
    {
        public int Id { get; set; }

        public string? PositionName { get; set; }

        public List<EmployeePosition>? EmployeePositions { get; set; }

        [JsonIgnore]
        public List<Employee>? PossibleEmployeePosition { get; set; }
    }
}