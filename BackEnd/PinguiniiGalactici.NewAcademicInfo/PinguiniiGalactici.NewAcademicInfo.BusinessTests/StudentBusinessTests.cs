using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinguiniiGalactici.NewAcademicInfo.Business;
using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business.Tests
{
    [TestClass()]
    public class StudentBusinessTests
    {
        Student student = new Student()
        {
            Name = "MihaiTest",
            Email = "mihai@gmail.com",
            GroupNumber = 935,
            RegistrationNumber = 12
        };
        private int studentsLengthBefore,studentsLengthAfter;
        [TestMethod()]
        public void StudentBusinessTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest()
        {
            User user = new User()
            {
                Username = "admin1",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            studentsLengthBefore = businessContext.StudentsBusiness.ReadAll().Count();
            businessContext.StudentsBusiness.Insert(student);
            studentsLengthAfter = businessContext.StudentsBusiness.ReadAll().Count();
            Assert.IsTrue(studentsLengthBefore+1==studentsLengthAfter);
        }



        [TestMethod()]
        public void ReadAllFromCourseTest()
        {
            User user = new User()
            {
                Username = "admin1",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            IEnumerable<Student> students = Enumerable.Empty<Student>();
            students = businessContext.StudentsBusiness.ReadAllFromCourse(Guid.Parse("0d223c71-6ddf-41e2-b266-25585f5b25f3"));
            Assert.IsTrue(students.Count() != 0);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            User user = new User()
            {
                Username = "admin1",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            User user = new User()
            {
                Username = "admin1",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            businessContext.StudentsBusiness.Delete(student.RegistrationNumber);
            studentsLengthAfter = businessContext.StudentsBusiness.ReadAll().Count();
            Assert.IsTrue(studentsLengthAfter == studentsLengthBefore);
        }
    }
}