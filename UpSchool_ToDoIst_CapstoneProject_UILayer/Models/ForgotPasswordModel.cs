using System.ComponentModel.DataAnnotations;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Models
{
    public class ForgotPasswordModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
