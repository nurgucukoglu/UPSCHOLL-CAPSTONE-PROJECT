using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos
{
    public class AppUserRegisterDto
    {

        public string UserName { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
