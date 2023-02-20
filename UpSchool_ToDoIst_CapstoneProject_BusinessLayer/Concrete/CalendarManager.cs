using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.UnitOfWork;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Concrete
{
    public class CalendarManager : ICalendarService
    {
        private readonly ICalendarDal _calendarDal;
        private readonly IUowDal _uowDal;

        public CalendarManager(ICalendarDal calendarDal, IUowDal uowDal)
        {
            _calendarDal = calendarDal;
            _uowDal = uowDal;
        }

        public void TDelete(Calendar t)
        {
            _calendarDal.Delete(t);
            _uowDal.Save();
        }

        public Calendar TGetById(int id)
        {
            return _calendarDal.GetById(id);
        }

        public List<Calendar> TGetList()
        {
            return _calendarDal.GetList();
        }

        public void TInsert(Calendar t)
        {
            _calendarDal.Insert(t);
            _uowDal.Save();
        }

        public void TUpdate(Calendar t)
        {
            _calendarDal.Update(t);
            _uowDal.Save();
        }
    }
}
