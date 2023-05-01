using Demo.DAL.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    public class DepartmentViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "the name is Requied")]
        [MaxLength(50,ErrorMessage ="The Max Length is 50 Digth")]
        public string name { get; set; }
        [Required(ErrorMessage = "the Code is Requied")]
        public string Code { get; set; }
        public DateTime Dataofcreation { get; set; }
        //Navigational Property [Many]
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
    }
}
