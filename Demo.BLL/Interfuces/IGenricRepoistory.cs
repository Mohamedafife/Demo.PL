using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfuces
{
    public interface IGenricRepoistory<T> where T : class
    {
        public Task<IEnumerable<T>> Getall();
        public Task<T> Get(int id);
        public Task<int> Add(T item);
        public Task<int> Update(T item);
        public Task<int> Delete(T item);
    }
}
