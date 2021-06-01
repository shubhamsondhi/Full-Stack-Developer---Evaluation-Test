using Full_Stack_Developer_Test.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Full_Stack_Developer_Test.Data
{
    public static class SeedData
    {

        public static void EnsureSeeded(this EmployeeContext context)
        {

            if (!context.Employee.Any())
            {
                var employee = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "employees.json"));
                context.AddRange(employee);
                context.SaveChanges();
            }


        }
    }
}
