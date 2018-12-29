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
    public class StudentDAL : DALObject
    {
        #region Constructors
        public StudentDAL(DALContext context) : base(context) { }
        private static string tableName = "Table1";
        #endregion

        #region Methods
        public IEnumerable<Student> ReadAll()
        {
            return DbOperations.ExecuteQuery<Student>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAll");
        }

        public Student ReadById(Int32 RegistrationNumber)
        {
            return DbOperations.ExecuteQuery<Student>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByID", new SqlParameter("RegistrationNumber", RegistrationNumber)).FirstOrDefault();
        }

        public IEnumerable<Student> ReadAllFromCourse(Guid CourseId)
        {
            return DbOperations.ExecuteQuery<Student>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByCourseID", new SqlParameter("CourseId", CourseId));
        }

        public void Insert(Student Students)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Insert", Students.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(Student Students)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Update", Students.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(Int32 RegistrationNumber)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Delete", new SqlParameter("RegistrationNumber", RegistrationNumber));
        }
        #endregion
    }
}
