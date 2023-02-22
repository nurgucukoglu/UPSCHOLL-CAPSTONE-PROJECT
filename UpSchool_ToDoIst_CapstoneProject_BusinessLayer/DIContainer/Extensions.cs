using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.ValidationRules.AppUserValidation;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.EntityFramework;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.UnitOfWork;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
			services.AddScoped<IMovieService, MovieManager>();
			services.AddScoped<IMovieDal, EFMovieDal>();

			services.AddScoped<ICalendarService, CalendarManager>();
			services.AddScoped<ICalendarDal, EFCalendarDal>();
			services.AddIdentity<AppUser, AppRole>()
				.AddDefaultTokenProviders()
			   .AddEntityFrameworkStores<Context>();
			services.AddScoped<IUowDal, UowDal>();
		}


        public static void CustomizeValidator(this IServiceCollection services)
        {
           
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<AppUserRegisterDto>, AppUserRegisterValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateValidator>();

        }
    }
}
