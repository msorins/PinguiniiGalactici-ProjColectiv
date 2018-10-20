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
        public void Insert(User user)
        {
            _context.DALContext.UserDAL.Insert(user);
        }

        public User ReadByUsername(string username)
        {
            return _context.DALContext.UserDAL.ReadByUsername(username);
        }

        public IEnumerable<User> ReadAll()
        {
            return _context.DALContext.UserDAL.ReadAll();
        }

        public void Update(User user)
        {
            _context.DALContext.UserDAL.Update(user);
        }

        public void Delete(string username)
        {
            _context.DALContext.UserDAL.Delete(username);
        }
        #endregion
    }
}
