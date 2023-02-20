using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-0LTDDDI\\SQLEXPRESS01; Database=ToDoItDb; integrated Security=True;");


        }
        //public DbSet<MoviesModel> MoviesModels { get; set; }
        public DbSet<MovieViews> MovieViews { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<Calendar> Calendars { get; set; }  
    }
}
