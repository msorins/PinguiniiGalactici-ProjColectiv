using PinguiniiGalactici.NewAcademicInfo.DAL.Core;
using PinguiniiGalactici.NewAcademicInfo.Library;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public User ReadUser(String username, String password)
        {
            _context.InitializeConnectionString(username,password);

            try
            {
                using (SqlConnection connection = new SqlConnection(_context.CONNECTION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("dbo.GetCurrentUserRole"))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    String role = reader.GetString(0);
                                    User user = new User
                                    {
                                        Username = username,
                                        Password = password,
                                        Role = role.ToLower().Equals("admin") ? Models.Enumerations.Role.Admin :
                                                role.ToLower().Equals("teacher") ? Models.Enumerations.Role.Teacher :
                                                Models.Enumerations.Role.Student
                                    };
                                    return user;
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }

            return null;
        }
        #endregion
    }
}
