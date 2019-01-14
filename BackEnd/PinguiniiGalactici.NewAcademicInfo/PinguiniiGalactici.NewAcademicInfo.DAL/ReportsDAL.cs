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
    public class ReportsDAL: DALObject
    {
        #region Constructors
        public ReportsDAL(DALContext context) : base(context) { }
        #endregion

        #region Methods
        public IEnumerable<AverageGradeReport> AverageGradesReport(Guid CourseID, Guid TypeID)
        {
            return DbOperations.ExecuteQuery<AverageGradeReport>(_context.CONNECTION_STRING, "dbo.Get_Average_Grade_For_Course_by_Attendance_Type", new SqlParameter("CourseID", CourseID), new SqlParameter("TypeID", TypeID));
        }

        public IEnumerable<PassingGradesReport> PassingGradesReport(Guid CourseID, Guid TypeID)
        {
            return DbOperations.ExecuteQuery<PassingGradesReport>(_context.CONNECTION_STRING, "dbo.Get_Passing_Grades_Number_For_Course_by_Attendance_Type", new SqlParameter("CourseID", CourseID), new SqlParameter("TypeID", TypeID));
        }
        
        public IEnumerable<GroupAttendacesReport> GroupAttendancesReport(Guid CourseID, Guid TypeID, Int32 GroupNumber)
        {
            return DbOperations.ExecuteQuery<GroupAttendacesReport>(_context.CONNECTION_STRING, "dbo.Get_Group_Attendances_for_Course_by_Attendance_Type", new SqlParameter("CourseID", CourseID), new SqlParameter("TypeID", TypeID), new SqlParameter("GroupNumber", GroupNumber));
        }

        public IEnumerable<GroupGradesReport> GroupGradesReport(Guid CourseID, Guid TypeID, Int32 GroupNumber)
        {
            return DbOperations.ExecuteQuery<GroupGradesReport>(_context.CONNECTION_STRING, "dbo.Get_Group_Grades_for_Course_by_Attendance_Type", new SqlParameter("CourseID", CourseID), new SqlParameter("TypeID", TypeID), new SqlParameter("GroupNumber", GroupNumber));
        }
        #endregion
    }
}
