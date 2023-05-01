using Demo.DAL.Entitys;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Demo.PL.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required ")]
        [MaxLength(50, ErrorMessage = "Mix Lenght of name is 50 chare")]
        [MinLength(5, ErrorMessage = "Min Lenght of name is 5 chare")]
        public string Name { get; set; }
        [Range(23, 40, ErrorMessage = "The age must be 23 or 40 at least")]
        public int Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address Must be like that 123-StreetNmae-CityName-CountryName")]
        public string Address { get; set; }
        public bool IsValed { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(6000, 8000, ErrorMessage = "Salary Must be Between This Rang 6000 | 8000")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime Hairdata { get; set; }
        //public DateTime Creatiomondata { get; set; } = DateTime.Now;
        public int? DepartmentId { get; set; }

        //Navigational Property [Own]
        public Department department { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
    }
}

    

