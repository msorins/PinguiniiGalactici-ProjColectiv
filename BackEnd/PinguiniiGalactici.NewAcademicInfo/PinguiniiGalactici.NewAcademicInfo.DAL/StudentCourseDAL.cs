using PinguiniiGalactici.NewAcademicInfo.DAL.Core;
using PinguiniiGalactici.NewAcademicInfo.Library;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PinguiniiGalactici.NewAcademicInfo.DAL
{
    public class StudentCourseDAL : DALObject
    {
        #region Constructors
        public StudentCourseDAL(DALContext context) : base(context) { }
        private static string tableName = "Table1Table3";
        #endregion

        #region Methods
        public IEnumerable<StudentCourse> ReadAll()
        {
            return DbOperations.ExecuteQuery<StudentCourse>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAll");
        }

        //aka ReadByID for the other models
        public StudentCourse ReadById(Guid enrollmentID)
        {
            return DbOperations.ExecuteQuery<StudentCourse>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByID", new SqlParameter("EnrollmentID", enrollmentID)).FirstOrDefault();
        }

        public void Insert(StudentCourse studentCourse)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Insert", studentCourse.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(StudentCourse studentCourse)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Update", studentCourse.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(Guid enrollmentID)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Delete", new SqlParameter("EnrollmentID", enrollmentID));
        }
        #endregion
    }
}
