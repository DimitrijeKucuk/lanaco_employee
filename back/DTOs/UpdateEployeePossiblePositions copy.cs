using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.DTOs
{
    public class UpdateEployeePossiblePositions
    {
        public int id { get; set; }
        public JobPosition? JobPosition { get; set; }
    }
}