using Demo.DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfuces
{
    public interface IEmployeeRepository:IGenricRepoistory<Employee>
    {
        IQueryable<Employee> GetEmployeeByName(string name);
    }
}
