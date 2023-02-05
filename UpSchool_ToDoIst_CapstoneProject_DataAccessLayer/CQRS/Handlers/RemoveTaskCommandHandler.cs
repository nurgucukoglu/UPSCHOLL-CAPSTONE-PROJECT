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
    
    public class RemoveTaskCommandHandler : IRequestHandler<RemoveTaskCommand>
    {
        private readonly Context _context;

        public RemoveTaskCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
        {
            var values = _context.Tasks.Find(request.id); //silinecek verileri bul
            _context.Tasks.Remove(values);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
