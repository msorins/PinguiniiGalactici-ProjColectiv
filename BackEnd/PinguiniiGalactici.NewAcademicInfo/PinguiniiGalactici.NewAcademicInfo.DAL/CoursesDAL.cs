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
    public class CoursesDAL : DALObject
    {
        #region Constructors
        public CoursesDAL(DALContext context) : base(context) { }
        private static string tableName = "Table3";
        #endregion

        #region Methods
        public IEnumerable<Course> ReadAll()
        {
            return DbOperations.ExecuteQuery<Course>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAll");
        }

        public Course ReadById(Guid CoursesID)
        {
            return DbOperations.ExecuteQuery<Course>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByID", new SqlParameter("CourseID", CoursesID)).FirstOrDefault();
        }

        public void Insert(Course Courses)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Insert", Courses.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(Course Courses)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Update", Courses.GenerateSqlParametersFromModel().ToArray());
        }

        public IEnumerable<Course> ReadAllForTeacher(Guid TeacherID)
        {
            return DbOperations.ExecuteQuery<Course>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAllForTeacher", new SqlParameter("TeacherID", TeacherID));
        }

        public void Delete(Guid CoursesID)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Delete", new SqlParameter("CourseID", CoursesID));
        }
        #endregion
    }
}
