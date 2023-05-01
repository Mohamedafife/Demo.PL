using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entitys
{
    public class Department
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        [Required]
        public string Code { get; set; }
        public DateTime Dataofcreation { get; set; }
        //Navigational Property [Many]
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
    }
}
