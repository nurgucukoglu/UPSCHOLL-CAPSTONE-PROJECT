using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.CalendarDto;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.ValidationRules.CalendarValidataion
{
    public class CalendarValidator:AbstractValidator<CalendarDto>
    {
        public CalendarValidator()
        {
            RuleFor(x => x.EventTitle).NotEmpty().WithMessage("Title boş geçilemez!");
            RuleFor(x => x.EventNote).NotEmpty().WithMessage("Note boş geçilemez!");
            RuleFor(x => x.EventDate).NotEmpty().WithMessage("Date boş geçilemez!");

        }
    }
}
