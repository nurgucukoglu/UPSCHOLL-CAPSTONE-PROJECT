using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos
{
    public class AppUserLoginDto
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }
    }
}
