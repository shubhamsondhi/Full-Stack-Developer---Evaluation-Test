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

        public async Task<int> Add(T obj)
        {
            await unitOfWork.GetRepository<T>().InsertAsync(obj);
            return await unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetOne(int id)
        {
            return await unitOfWork.GetRepository<T>().GetFirstOrDefaultAsync(predicate: p => p.Id == id);
        }

        public bool Any(int id)
        {
            return unitOfWork.GetRepository<T>().Count(predicate: p => p.Id == id) > 0;
        }
        public async Task Remove(int id)
        {
            unitOfWork.GetRepository<T>().Delete(id);
            unitOfWork.SaveChanges();
        }

        public async Task Update(T obj)
        {
            try
            {
                unitOfWork.GetRepository<T>().Update(obj);
                unitOfWork.SaveChanges();


            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
