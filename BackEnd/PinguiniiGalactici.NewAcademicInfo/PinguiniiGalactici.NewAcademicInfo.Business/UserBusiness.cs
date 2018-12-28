using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class UserBusiness : BusinessObject
    {
        #region Constructor
        public UserBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public User ReadUser(String username, String password)
        {
            return _context.DALContext.UserDAL.ReadUser(username,password);
        }
        #endregion
    }
}

