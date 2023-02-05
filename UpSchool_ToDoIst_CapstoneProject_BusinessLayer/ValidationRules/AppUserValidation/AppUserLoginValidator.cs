using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.ValidationRules.AppUserValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("mail boş geçilemez!");
            RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("şifre boş geçilemez!");
        }
    }
}
