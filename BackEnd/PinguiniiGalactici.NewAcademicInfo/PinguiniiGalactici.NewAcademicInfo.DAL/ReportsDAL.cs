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
        public IEnumerable<AverageGradeReport> AverageGradesReport(Guid CourseID, String TypeName)
        {
            return DbOperations.ExecuteQuery<AverageGradeReport>(_context.CONNECTION_STRING, "dbo.Get_Average_Grade_For_Course_by_Attendance_Type", new SqlParameter("CourseID", CourseID), new SqlParameter("TypeName", TypeName));
        }

        public IEnumerable<PassingGradesReport> PassingGradesReport(Guid CourseID, String TypeName)
        {
            return DbOperations.ExecuteQuery<PassingGradesReport>(_context.CONNECTION_STRING, "dbo.Get_Passing_Grades_Number_For_Course_by_Attendance_Type", new SqlParameter("CourseID", CourseID), new SqlParameter("TypeName", TypeName));
        }
        #endregion
    }
}
