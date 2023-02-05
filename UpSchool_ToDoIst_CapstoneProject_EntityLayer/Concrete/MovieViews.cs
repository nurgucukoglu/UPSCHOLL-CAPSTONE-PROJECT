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
        Istanbul=500,
        Berlin=300,
        Londra=700,
        Washington=600,
        Tokyo=800
        
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
