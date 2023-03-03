using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Entities
{
    public class Deducation
    {
        public int Id { get; set; }

        public Employee? Employee { get; set; }

        public double Amount { get; set; }

        public DateTime DeducationDate { get; set; }

    }
}