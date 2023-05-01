using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entitys
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public bool IsValed { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Hairdata { get; set; }
        public DateTime Creatiomondata { get; set; } = DateTime.Now;
        public int? DepartmentId { get; set; }

        //Navigational Property [Own]
        public Department department { get; set; }
        public string ImageName { get; set; }
    }
}
