using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Queries;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Results;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Handlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, GetTaskByIdQueryResult>
    {
        private readonly Context _context;

        public GetTaskByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetTaskByIdQueryResult> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Tasks.FindAsync(request.id);

            return new GetTaskByIdQueryResult
            {
                TaskId = values.TaskId,
                Date= values.Date,
                MovieName= values.MovieName,
                Note = values.Note,
                Status = values.Status
            };

        }
    }
}
