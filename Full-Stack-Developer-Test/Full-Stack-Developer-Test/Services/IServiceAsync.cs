using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Full_Stack_Developer_Test.Service
{
    public interface IServiceAsync<T>
    {
        public IEnumerable<T> GetAll();
        public Task<int> Add(T obj);
        public Task<int> Update(T obj);
        public Task<int> Remove(int id);
        public Task<T> GetOne(int id);
        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
    }

}
