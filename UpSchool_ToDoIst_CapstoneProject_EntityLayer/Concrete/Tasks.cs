using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        //public MoviesModel MoviesModel { get; set; }

        public string Note { get; set; }
        public string MovieType { get; set; }
        public string MovieName { get; set; }


    }
}

