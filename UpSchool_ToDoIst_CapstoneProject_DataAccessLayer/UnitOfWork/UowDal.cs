using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.UnitOfWork
{
    public class UowDal : IUowDal
    {
        private readonly Context _context;

        public UowDal(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        } //context.in nerden geldiğini EF d e yazıcam.
    }
}
