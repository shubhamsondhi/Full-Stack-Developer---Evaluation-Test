using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Full_Stack_Developer_Test.Entity;

namespace Full_Stack_Developer_Test.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext (DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Full_Stack_Developer_Test.Entity.Employee> Employee { get; set; }
    }
}
