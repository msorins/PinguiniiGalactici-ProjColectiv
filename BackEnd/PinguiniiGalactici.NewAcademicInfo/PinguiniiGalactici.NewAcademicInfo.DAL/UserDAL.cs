using PinguiniiGalactici.NewAcademicInfo.DAL.Core;
using PinguiniiGalactici.NewAcademicInfo.Library;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.DAL
{
    public class UserDAL : DALObject
    {
        #region Constructors
        public UserDAL(DALContext context) : base(context) { }
        #endregion

        #region Methods
        public IEnumerable<User> ReadAll()
        {
            return DbOperations.ExecuteQuery<User>(_context.CONNECTION_STRING, "dbo.Users_ReadAll");
        }

        //aka ReadByID for the other models
        public User ReadByUsername(string username)
        {
            return DbOperations.ExecuteQuery<User>(_context.CONNECTION_STRING, "dbo.Users_ReadByID", new SqlParameter("Username", username)).FirstOrDefault();
        }

        public void Insert(User user)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo.Users_Insert", user.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(User user)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo.Users_Update", user.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(string username)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo.Users_Delete", new SqlParameter("Username", username));
        }
        #endregion
    }
}
