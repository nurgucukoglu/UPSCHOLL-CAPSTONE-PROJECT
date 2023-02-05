using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetAllTaskQueryHandler : IRequestHandler<GetAllTaskQuery, List<GetAllTaskQueryResult>>
    {

        private readonly Context _context;

        public GetAllTaskQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllTaskQueryResult>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tasks.Select(x =>
            new GetAllTaskQueryResult
            {
                TaskId = x.TaskId,
                Status = x.Status,
                Date = x.Date,
                MovieName = x.MovieName,
                Note = x.Note,

            }).AsNoTracking().ToListAsync();


        }
    }
}
