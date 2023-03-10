using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
	{
        void Insert(T t);
        void Update(T t);
        void Delete(T t); //burdaki metotların tanımlaması opsiyonel. fakat managerda.da o isimle çağırılması gerekir 
        List<T> GetList();
        T GetById(int id);
    }
}
