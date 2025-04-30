using Core.Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using Moq;
using Moq.EntityFrameworkCore;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            // ARRANGE
            var students = new List<StudentInfo>
            {
                new StudentInfo {Id =1,Name="Anjali", Subject="Maths"},
                new StudentInfo {Id =2,Name="xyz", Subject="Science"}
            };
            var context = new Mock<ApplicationDbContext>();
            context.Setup(c=> c.Students).ReturnsDbSet(students);

            var service = new Student(context.Object);

            //Act
            var result=await service.GetAllStudentsAsync();

            //var result = await service.AddStudentAsync(Student students);

            //Assert
            Assert.AreEqual(2,result.Count);
            Assert.AreEqual("Anjali",result[0].Name);
            Assert.AreEqual("xyz", result[1].Name);
        }
    }
}