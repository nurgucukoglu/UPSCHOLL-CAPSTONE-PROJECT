using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete
{
    public class AppUser: IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ImageURL { get; set; }
        public string Gender { get; set; }
        public string EmailConfirmedControlCode { get; set; }
    }
}
