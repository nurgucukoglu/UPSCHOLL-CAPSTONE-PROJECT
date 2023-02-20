using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Commands;
using UpSchool_ToDoIst_CapstoneProject_EntityLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
    {
        private readonly Context _context;

        public CreateTaskCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            _context.Tasks.Add(new Tasks
            {
                Status=request.Status,
                Date= request.Date,
                MovieName= request.MovieName,
                Note= request.Note,
                //TaskId= request.TaskId,

            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
