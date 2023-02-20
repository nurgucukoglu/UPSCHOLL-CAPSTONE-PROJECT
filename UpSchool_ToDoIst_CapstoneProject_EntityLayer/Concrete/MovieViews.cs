using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete
{
    public enum Counrty
    {
        Istanbul=1,
        Berlin=2,
        Londra=3,
        Washington=4,
        Tokyo=5
        
    }
    public class MovieViews
    {
        [Key]
        public int ViewId { get; set; }
        public Counrty Counrty { get; set; }
        public int Count { get; set; }
        public DateTime ViewDate { get; set; }
    }
}
