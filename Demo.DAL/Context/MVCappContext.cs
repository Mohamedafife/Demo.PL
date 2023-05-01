using Demo.DAL.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.DAL.Context
{ 
    public class MVCappContext : IdentityDbContext<ApplictionUser>
    {
        public MVCappContext(DbContextOptions<MVCappContext> options):base(options)//Constructor Channing
        {
                
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        //=> optionsBuilder.UseSqlServer("Server = .; Database = MVCapp; Trusted_Connction = true ");

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        //public DbSet<IdentityUser> AspNetUsers { get; set; }

    }
}
