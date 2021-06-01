using Arch.EntityFrameworkCore.UnitOfWork;
using Full_Stack_Developer_Test.Data;
using Full_Stack_Developer_Test.DTO;
using Full_Stack_Developer_Test.Entity;
using Full_Stack_Developer_Test.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Full_Stack_Developer_Test.Services
{
    public class EmployeeService<T> : GenericService<T> where T : Employee
    {
        private readonly IUnitOfWork<EmployeeContext> unitOfWork;
        public EmployeeService(IUnitOfWork<EmployeeContext> _unitOfWork) : base(_unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<List<EmployeeResponse>> GetNameAndRoleAsync()
        {
            var empolyee =await unitOfWork.GetRepository<Employee>().GetPagedListAsync(
                pageSize:5000,
                selector: employee => new EmployeeResponse() {
                    Fullname = employee.FirstName+" "+ employee.LastName, 
                    Id= employee.Id, Role=employee.Role });
         
            return empolyee.Items.ToList();
        }
    }
}
