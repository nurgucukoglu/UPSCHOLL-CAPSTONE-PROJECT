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
    public class EFCalendarDal : GenericRepository<Calendar> ,ICalendarDal
    {
		private IServiceProvider _serviceProvider;
		//Generic Repository içinde context alan constructor olduğundan 
		//o constructor burada da tanımlanır
		//const aşağıda base class alıyor.
		public EFCalendarDal(Context context, IServiceProvider serviceProvider) : base(context)
		{
			_serviceProvider = serviceProvider;
		}


	}
}
