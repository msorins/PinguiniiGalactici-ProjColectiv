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
    public class CourseBusinessTests
    {

        private Guid courseGuid = new Guid();
        private Guid departmentGuid = new Guid();
        private Guid facultyGuid = new Guid();
        private IEnumerable<Course> courses = Enumerable.Empty<Course>();
        private int coursesLength,departmentLength,facultyLength;
        private int coursesLength2, departmentLength2, facultyLength2;
        //private User user = new User()
        // {
        //     Username = "admin1",
        //     Password = "pass",
        //     Role = Models.Enumerations.Role.Admin
        // };
        // BusinessContext businessContext = new BusinessContext(user);

        [TestMethod()]
        public void CourseBusinessTest()
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
        public void InsertTest()
        {
            User user = new User()
            {
                Username = "admin1",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            //add the faculty
            facultyLength = businessContext.FacultyBusiness.ReadAll().Count();
            Faculty fac = new Faculty()
            {
                FacultyID = facultyGuid,
                Name = "FacultyTest"
            };
            businessContext.FacultyBusiness.Insert(fac);
            facultyLength2 = businessContext.FacultyBusiness.ReadAll().Count();


            //add the department
            departmentLength = businessContext.DepartmentBusiness.ReadAll().Count();
            Department department = new Department()
            {
                DepartmentID = departmentGuid,
                Name = "DepartmentTest",
                FacultyID = facultyGuid

            };
            businessContext.DepartmentBusiness.Insert(department);
            departmentLength2 = businessContext.DepartmentBusiness.ReadAll().Count();

            courses = businessContext.CoursesBusiness.ReadAll();
            coursesLength = businessContext.CoursesBusiness.ReadAll().Count();
            Course course = new Course()
            {
                CourseID =courseGuid,
                Name = "TestCourse",
                DepartmentID =departmentGuid,
                Year = 2018,
                TotalLabNr = 32,
                TotalSeminarNr = 20

            };
            businessContext.CoursesBusiness.Insert(course);
            coursesLength2 = businessContext.CoursesBusiness.ReadAll().Count();
            IEnumerable<Course> courses2 = Enumerable.Empty<Course>();
            courses2 = businessContext.CoursesBusiness.ReadAll();
            Assert.IsTrue(coursesLength == courses2.Count() + 1);
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            User user = new User()
            {
                Username = "admin1",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            IEnumerable<Course> courses = Enumerable.Empty<Course>();
            courses = businessContext.CoursesBusiness.ReadAll();
            Assert.IsTrue(coursesLength != 0);
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
            businessContext.CoursesBusiness.Delete(courseGuid);
            Assert.IsTrue(coursesLength == coursesLength2 - 1);
            businessContext.DepartmentBusiness.Delete(departmentGuid);
            Assert.IsTrue(departmentLength == departmentLength2 - 1);
            businessContext.FacultyBusiness.Delete(facultyGuid);
            Assert.IsTrue(facultyLength == facultyLength2 - 1);
        }
    }
}