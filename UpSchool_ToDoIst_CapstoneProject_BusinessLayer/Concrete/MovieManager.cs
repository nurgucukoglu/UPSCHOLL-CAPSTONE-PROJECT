using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public void TDelete(MoviesModel t)
        {
            _movieDal.Delete(t);
        }

        public MoviesModel TGetById(int id)
        {
            return _movieDal.GetById(id);
        }

        public List<MoviesModel> TGetList()
        {
            return _movieDal.GetList();
        }

        public void TInsert(MoviesModel t)
        {
            _movieDal.Insert(t);
        }

        public void TUpdate(MoviesModel t)
        {
            _movieDal.Update(t);
        }
    }
}
