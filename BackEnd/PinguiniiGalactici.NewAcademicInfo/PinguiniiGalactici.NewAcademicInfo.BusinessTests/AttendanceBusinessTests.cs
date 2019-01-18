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
    public class AttendanceBusinessTests
    {
        private Guid attendanceGuid, enrollmentGuid, typeGuid;
        private int lengthBefore, lengthAfter;


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
            lengthBefore = businessContext.AttendancesBusiness.ReadAll().Count();
            Attendance attendance = new Attendance()
            {
                AttendanceID = attendanceGuid,
                EnrollmentID = enrollmentGuid,
                TypeID = typeGuid,
                Grade = 9,
                WeekNr = 12
            };
            businessContext.AttendancesBusiness.Insert(attendance);
            lengthAfter = businessContext.AttendancesBusiness.ReadAll().Count();

            Assert.IsTrue(lengthAfter != lengthBefore);
        }

        [TestMethod()]
        public void ReadByIdTest()
        {
            User user = new User()
            {
                Username = "admin1",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            Attendance attendance = businessContext.AttendancesBusiness.ReadById(attendanceGuid);
            Assert.IsNotNull(attendance.EnrollmentID);
        }


        [TestMethod()]
        public void ReadAllWithCoursesTest()
        {
            //Assert.Fail();
            User user = new User()
            {
                Username = "admin1",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
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
            businessContext.AttendancesBusiness.Delete(attendanceGuid);
            lengthAfter = businessContext.AttendancesBusiness.ReadAll().Count();
            Assert.IsTrue(lengthAfter == lengthBefore);
        }

    }
}