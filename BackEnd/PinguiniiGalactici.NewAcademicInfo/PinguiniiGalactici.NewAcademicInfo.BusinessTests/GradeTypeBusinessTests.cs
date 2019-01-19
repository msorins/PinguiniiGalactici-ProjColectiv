using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinguiniiGalactici.NewAcademicInfo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business.Tests
{
    [TestClass()]
    public class GradeTypeBusinessTests
    {
        [TestMethod()]
        public void GradeTypeBusinessTest()
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
        public void InsertTest()
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
        public void ReadByIdTest()
        {

            User user = new User()
            {
                Username = "admin@gmail.com",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user); ;
        }

        [TestMethod()]
        public void ReadAllTest()
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
        }
    }
}