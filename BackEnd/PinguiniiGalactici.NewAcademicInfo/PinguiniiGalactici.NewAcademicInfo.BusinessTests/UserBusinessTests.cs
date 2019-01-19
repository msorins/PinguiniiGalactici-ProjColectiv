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
    public class UserBusinessTests
    {
        [TestMethod()]
        public void ReadUserTest()
        {

            User user = new User()
            {
                Username = "admin@gmail.com",
                Password = "pass",
                Role = Models.Enumerations.Role.Admin
            };
            BusinessContext businessContext = new BusinessContext(user);

            User newUser = businessContext.UserBusiness.ReadUser(user.Username, user.Password);
            Assert.IsTrue(user != null);
        }
    }
}