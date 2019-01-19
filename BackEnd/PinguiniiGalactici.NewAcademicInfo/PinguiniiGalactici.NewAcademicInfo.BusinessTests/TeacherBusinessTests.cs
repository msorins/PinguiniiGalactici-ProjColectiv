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
    public class TeacherBusinessTests
    {
        private Guid teacherGuid = new Guid();
        private int lengthBefore, lengthAfter;
        [TestMethod()]
        public void TeacherBusinessTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTest()
        {

            User user = new User()
            {
                Username = "admin@gmail.com",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            lengthBefore = businessContext.TeachersBusiness.ReadAll().Count();

            Teacher teacher = new Teacher()
            {
                TeacherID = this.teacherGuid,
                Name = "MihaiTest",
            };

            businessContext.TeachersBusiness.Insert(teacher);
            lengthAfter = businessContext.TeachersBusiness.ReadAll().Count();
            Assert.IsTrue(lengthBefore != lengthAfter);

        }

        [TestMethod()]
        public void ReadByIdTest()
        {
            User user = new User()
            {
                Username = "admin@gmail.com",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            Teacher teacher = businessContext.TeachersBusiness.ReadById(teacherGuid);
            Assert.IsNotNull(teacher.Name);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            User user = new User()
            {
                Username = "admin@gmail.com",
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
                Username = "admin@gmail.com",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);
            businessContext.TeachersBusiness.Delete(teacherGuid);
            lengthAfter = businessContext.TeachersBusiness.ReadAll().Count();
            Assert.IsTrue(lengthAfter == lengthBefore);
        }
    }
}