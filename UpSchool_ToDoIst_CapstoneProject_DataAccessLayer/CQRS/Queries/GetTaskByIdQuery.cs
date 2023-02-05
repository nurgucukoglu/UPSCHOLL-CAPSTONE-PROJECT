﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Results;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.CQRS.Queries
{
    public class GetTaskByIdQuery:IRequest<GetTaskByIdQueryResult>
    {
        public GetTaskByIdQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
