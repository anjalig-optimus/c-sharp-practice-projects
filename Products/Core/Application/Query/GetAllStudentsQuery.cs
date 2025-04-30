using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Entities;
using MediatR;

namespace Core.Application.Query
{
    public class GetAllStudentsQuery:IRequest<List<StudentInfo>>
    {

    }
}
