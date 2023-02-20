using AutoMapper;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.AppUserDtos;
using UpSchool_ToDoIst_CapstoneProject_DTOLayer.CalendarDto;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_UILayer.Models;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Mapping.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {

            CreateMap<AppUserLoginDto, AppUser>(); //ekrandan alıp içeri
            CreateMap<AppUser, AppUserLoginDto>(); //db.den alıp kullanıcıya

            CreateMap<AppUserRegisterDto, AppUser>().ReverseMap();
            CreateMap<AppUserUpdateDto, AppUser>().ReverseMap();
            CreateMap<CalendarDto, Calendar>().ReverseMap();

        }
    }
}
