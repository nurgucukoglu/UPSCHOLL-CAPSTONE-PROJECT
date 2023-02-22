using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Repository;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.EntityFramework
{
    public class EFMovieDal : GenericRepository<MoviesModel>, IMovieDal
    {
		private IServiceProvider _serviceProvider;
		public EFMovieDal(Context context, IServiceProvider serviceProvider) : base(context)
		{
			_serviceProvider = serviceProvider;
		}
	}
}
