using AutoMapper;
using Demo.DAL.Entitys;
using Demo.PL.Models;

namespace Demo.PL.Mapper
{
    public class DepartmetProfile:Profile
    {
        public DepartmetProfile()
        {
            CreateMap<DepartmentViewModel,Department>().ReverseMap();
        }
    }
}
