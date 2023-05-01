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
    public class DepartmentRepository :GenricRepoistory<Department> ,IDepartmentRepositore
    {
        private readonly MVCappContext _context;
        public DepartmentRepository(MVCappContext dbcontext) : base(dbcontext)
        {
            _context = dbcontext;
        }


    }
}
