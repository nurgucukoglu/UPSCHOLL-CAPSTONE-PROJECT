using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Commands
{
    public class RemoveTaskCommand:IRequest
    {
        public RemoveTaskCommand(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
