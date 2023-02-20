using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_DTOLayer.CalendarDto
{
    public class CalendarDto
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }    
        public string EventNote { get; set; }
        public DateTime EventDate { get; set; }
    }
}
