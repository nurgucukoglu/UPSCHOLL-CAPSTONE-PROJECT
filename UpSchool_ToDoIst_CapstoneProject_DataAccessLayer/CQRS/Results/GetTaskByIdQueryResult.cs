using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Results
{
    public class GetTaskByIdQueryResult
    {
        [Key]
        public int TaskId { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string MovieName { get; set; }
    }
}
