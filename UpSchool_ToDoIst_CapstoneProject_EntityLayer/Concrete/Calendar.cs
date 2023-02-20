using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete
{
    public class Calendar
    {
        [Key]
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public bool EventType { get; set; }
        public string  EventNote { get; set; }
        public DateTime EventDate { get; set; }
    }
}
