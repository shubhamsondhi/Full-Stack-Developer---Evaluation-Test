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
        private readonly IUnitOfWork<EmployeeContext> _unitOfWork;
        public EmployeeService(IUnitOfWork<EmployeeContext> unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<EmployeeResponse>> GetNameAndRoleAsync()
        {
            var empolyee =await _unitOfWork.GetRepository<Employee>().GetPagedListAsync(
                pageSize:20,
                orderBy:empolyee=>empolyee.OrderByDescending(s=>s.Id),
                selector: employee => new EmployeeResponse() {
                    Fullname = employee.FullName, 
                    Id= employee.Id, Role=employee.Role });
         
            return empolyee.Items.ToList();
        }
    }
}
