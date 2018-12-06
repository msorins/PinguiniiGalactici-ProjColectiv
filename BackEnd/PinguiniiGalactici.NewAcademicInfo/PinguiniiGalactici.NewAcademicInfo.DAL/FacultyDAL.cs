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
    public class FacultyDAL : DALObject
    {
        #region Constructors
        public FacultyDAL(DALContext context) : base(context) { }
        #endregion

        #region Methods
        public IEnumerable<Faculty> ReadAll()
        {
            return DbOperations.ExecuteQuery<Faculty>(_context.CONNECTION_STRING, "dbo.Faculties_ReadAll");
        }

        public Faculty ReadByID(Guid facultyID)
        {
            return DbOperations.ExecuteQuery<Faculty>(_context.CONNECTION_STRING, "dbo.Faculties_ReadByID", new SqlParameter("FacultyID", facultyID)).FirstOrDefault();
        }

        public void Insert(Faculty faculty)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo.Faculties_Insert", faculty.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(Faculty faculty)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo.Faculties_Update", faculty.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(Guid facultyID)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo.Faculties_Delete", new SqlParameter("FacultyID", facultyID));
        }
        #endregion
    }
}
