using Core.Application.Query;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private readonly IStudent _student;
        //public StudentController(IStudent student)
        //{
        //    _student = student;
        //}

        IMediator mediator;
        public StudentController(IMediator md)
        {
            mediator = md; 
        }
        [HttpGet]
        public async Task<IActionResult> GetAll () {
           //var students=await _student.GetAllStudentsAsync();
           // return Ok(students);
           var result=await mediator.Send(new GetAllStudentsQuery() );
            return Ok(result);
        }
        //[HttpPost]
        //public async Task<IActionResult> Post(StudentInfo student)
        //{
        //    await _student.AddStudentAsync(student);
        //    return Ok(student);
        //}
    }
}
