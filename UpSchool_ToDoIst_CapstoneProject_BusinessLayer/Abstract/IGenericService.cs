using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(T t); //burdaki metotların tanımlaması opsiyonel. fakat managerda.da o isimle çağırılması gerekir 
        List<T> TGetList();
        T TGetById(int id);
    }
}
