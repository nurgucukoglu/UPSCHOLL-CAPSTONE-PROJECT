using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.EntityFramework;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.UnitOfWork;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _movieDal;
        private readonly IUowDal _uowDal;

        public MovieManager(IMovieDal movieDal, IUowDal uowDal)
        {
            _movieDal = movieDal;
            _uowDal = uowDal;
        }

        public void TDelete(MoviesModel t)
        {
            _movieDal.Delete(t);
            _uowDal.Save();
        }

        public MoviesModel TGetById(int id)
        {
            return _movieDal.GetById(id);
        }

        public List<MoviesModel> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(MoviesModel t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MoviesModel t)
        {
            throw new NotImplementedException();
        }
    }
}
