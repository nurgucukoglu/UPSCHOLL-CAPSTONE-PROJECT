using FluentValidation;
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
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.EntityFramework;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<IMovieDal, EFMovieDal>();

            services.AddScoped<ICalendarService, CalendarManager>();
            services.AddScoped<ICalendarDal , EFCalendarDal>();
        }


        public static void CustomizeValidator(this IServiceCollection services)
        {
            //DTO ve onun ilgili validator eşleştirmelerini burada yazıp tanımlıyoruz

            //services.AddTransient<IValidator<AppUserLoginDTO>, AppUserLoginValidator>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();

            services.AddTransient<IValidator<AppUserRegisterDto>, AppUserRegisterValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateValidator>();




        }
    }
}
