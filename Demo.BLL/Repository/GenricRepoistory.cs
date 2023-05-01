using Demo.BLL.Interfuces;
using Demo.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repository
{
    public class GenricRepoistory<T> : IGenricRepoistory<T> where T : class
    {
        private readonly MVCappContext _dbcontext;
        public GenricRepoistory(MVCappContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Add(T item)
        {
            await _dbcontext.Set<T>().AddAsync(item);
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<int> Delete(T item)
        {
            _dbcontext.Set<T>().Remove(item);
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task <IEnumerable<T>> Getall()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<int> Update(T item)
        {
           _dbcontext.Set<T>().Update(item);
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
