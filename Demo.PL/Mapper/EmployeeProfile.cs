using AutoMapper;
using Demo.DAL.Entitys;
using Demo.PL.Models;

namespace Demo.PL.Mapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel,Employee>().ReverseMap();
        }
    }
}
