using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class Student:IStudent
    {
        private readonly ApplicationDbContext _context;

        public Student(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<StudentInfo>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task AddStudentAsync(StudentInfo students)
        {
            StudentInfo newStudent = new StudentInfo()
            {
                Name = students.Name,
                Subject = students.Subject
            };
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
        }
    }
}
