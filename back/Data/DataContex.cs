using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back.Data
{
    public class DataContex : DbContext
    {
        public DataContex(DbContextOptions<DataContex> options) : base(options)
        {
            
        }

        public DbSet<JobPosition> JobPosition => Set<JobPosition>();
        public DbSet<Employee> Employee => Set<Employee>();
        public DbSet<EmployeePosition> EmployeePosition => Set<EmployeePosition>();
        public DbSet<Salary> Salary => Set<Salary>();
        public DbSet<Bonus> Bonus => Set<Bonus>();
        public DbSet<Deducation> Deducation => Set<Deducation>();
    }

}