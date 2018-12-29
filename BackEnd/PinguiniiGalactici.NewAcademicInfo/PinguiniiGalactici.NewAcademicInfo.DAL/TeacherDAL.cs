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
    public class TeacherDAL : DALObject
    {
        #region Constructors
        public TeacherDAL(DALContext context) : base(context) { }
        private static string tableName = "Table2";
        #endregion

        #region Methods
        public IEnumerable<Teacher> ReadAll()
        {
            return DbOperations.ExecuteQuery<Teacher>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAll");
        }

        public Teacher ReadById(Guid TeachersID)
        {
            return DbOperations.ExecuteQuery<Teacher>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByID", new SqlParameter("TeacherID", TeachersID)).FirstOrDefault();
        }

        public void Insert(Teacher Teachers)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Insert", Teachers.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(Teacher Teachers)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Update", Teachers.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(Guid TeachersID)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Delete", new SqlParameter("TeacherID", TeachersID));
        }
        #endregion
    }
}
