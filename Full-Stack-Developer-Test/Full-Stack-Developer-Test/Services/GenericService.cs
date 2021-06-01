using Arch.EntityFrameworkCore.UnitOfWork;
using Full_Stack_Developer_Test.Data;
using Full_Stack_Developer_Test.Entity;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Full_Stack_Developer_Test.Service
{
    public class GenericService<T> : IServiceAsync<T> where T : BaseEntity
    {
        public IUnitOfWork<EmployeeContext> unitOfWork;
        public GenericService(IUnitOfWork<EmployeeContext> _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public Task<int> Add(T obj)
        {
            unitOfWork.GetRepository<T>().InsertAsync(obj);
            return unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return unitOfWork.GetRepository<T>().GetAll();
        }

        public Task<T> GetOne(int id)
        {
            return unitOfWork.GetRepository<T>().GetFirstOrDefaultAsync(predicate: p => p.Id == id);
        }

        public bool Any(int id)
        {
            return unitOfWork.GetRepository<T>().Count(predicate: p => p.Id == id)>0;
        }
        public Task<int> Remove(int id)
        {
            unitOfWork.GetRepository<T>().Delete(id);
            return unitOfWork.SaveChangesAsync();
        }

        public Task<int> Update(T obj)
        {
            try
            {
                unitOfWork.GetRepository<T>().Update(obj);


            }
            catch (DbUpdateConcurrencyException)
            {
               
                    throw;
                
            }
            return unitOfWork.SaveChangesAsync();
        }

   
    }
}
