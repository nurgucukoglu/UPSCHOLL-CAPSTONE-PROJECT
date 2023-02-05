using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Commands;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly Context _context;

        public UpdateTaskCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var values = _context.Tasks.Find(request.TaskId);
            values.MovieName= request.MovieName;
            values.Status= request.Status;
            values.Date= request.Date;
            values.Note= request.Note;

            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
