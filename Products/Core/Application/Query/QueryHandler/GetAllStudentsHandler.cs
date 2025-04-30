using Core.Domain.Entities;
using MediatR;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Interfaces;

namespace Core.Application.Query.QueryHandler
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<StudentInfo>>
    {
        IStudent sturepo;

        public GetAllStudentsHandler(IStudent st)
        {
            sturepo = st;  
        }
        public Task<List<StudentInfo>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return sturepo.GetAllStudentsAsync();
            
        }
    }
}
