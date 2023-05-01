using Demo.BLL.Interfuces;
using Demo.DAL.Context;
using Demo.DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repository
{
    public class EmployeeRepoistory : GenricRepoistory<Employee>,IEmployeeRepository
    {
        private readonly MVCappContext _dbcontext;

        public EmployeeRepoistory(MVCappContext dbcontext):base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IQueryable<Employee> GetEmployeeByName(string name)
        {
            return _dbcontext.Employees.Where(e => e.Name.Contains(name));
        }
    }
}
