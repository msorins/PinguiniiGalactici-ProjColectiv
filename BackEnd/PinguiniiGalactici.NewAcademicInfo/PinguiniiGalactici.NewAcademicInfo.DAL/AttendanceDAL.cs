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
    public class AttendanceDAL : DALObject
    {
        #region Constructors
        public AttendanceDAL(DALContext context) : base(context) { }
        private static string tableName = "Table4";
        #endregion

        #region Methods
        public IEnumerable<Attendance> ReadAll()
        {
            return DbOperations.ExecuteQuery<Attendance>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAll");
        }

        public Attendance ReadById(Guid AttendanceID)
        {
            return DbOperations.ExecuteQuery<Attendance>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByID", new SqlParameter("AttendanceID", AttendanceID)).FirstOrDefault();
        }

        public void Insert(Attendance attendances)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Insert", attendances.GenerateSqlParametersFromModel().ToArray());
        }

        public IEnumerable<Attendance> ReadForStudent()
        {
            return DbOperations.ExecuteQuery<Attendance>(_context.CONNECTION_STRING, "dbo.Table1_ReadTable4");
        }

        public void Update(Attendance attendances)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Update", attendances.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(Guid AttendanceID)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Delete", new SqlParameter("AttendanceID", AttendanceID));
        }

        public IEnumerable<AttendancesCourses> ReadAllWithCourses()
        {
            return DbOperations.ExecuteQuery<AttendancesCourses>(_context.CONNECTION_STRING, "dbo.GetAttendancesWithCourses");
        }

        public IEnumerable<AttendancesCourses> ReadAllWithCourseAndStudent(Guid courseID, int registrationNumber)
        {
            return DbOperations.ExecuteQuery<AttendancesCourses>(_context.CONNECTION_STRING, "dbo.GetAttendancesWithCourseAndStudent", new SqlParameter("CourseID", courseID), new SqlParameter("RegistrationNumber", registrationNumber));
        }

        public void UpdateOrInsert(int studentID, Guid courseID, int weekNr, Guid TypeID, decimal? grade)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_UpdateOrInsert", new SqlParameter("StudentID", studentID),
                                                                                                            new SqlParameter("CourseID", courseID),
                                                                                                            new SqlParameter("WeekNr", weekNr),
                                                                                                            new SqlParameter("TypeID", TypeID),
                                                                                                            new SqlParameter("Grade", grade));
        }
        #endregion
    }
}
