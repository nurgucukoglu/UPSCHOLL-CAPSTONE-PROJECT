using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.ValidationRules.AppUserValidation
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("username boş geçilemez!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("mail boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Soyadı boş geçilemez!");          
            RuleFor(x => x.Password).NotEmpty().WithMessage("Soyadı boş geçilemez!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Soyadı boş geçilemez!");
          
        }
    }
}
