using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete
{
    public class MovieViewChart
    {
        public MovieViewChart()
        {
            Counts = new List<int>();
        }

        public string ViewDate { get; set; }
        public List<int> Counts { get; set; } // o tarihte consuma edilen değer
    }
}
