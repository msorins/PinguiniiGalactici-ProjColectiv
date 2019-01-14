using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class ReportsBusiness: BusinessObject
    {
        #region Constructor
        public ReportsBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public IEnumerable<AverageGradeReport> AverageGradesReport(Guid CourseID, Guid TypeID)
        {
            return _context.DALContext.ReportsDAL.AverageGradesReport(CourseID, TypeID);
        }
        public IEnumerable<PassingGradesReport> PassingGradesReport(Guid CourseID, Guid TypeID)
        {
            return _context.DALContext.ReportsDAL.PassingGradesReport(CourseID, TypeID);
        }

        public IEnumerable<GroupAttendacesReport> GroupAttendancesReport(Guid CourseID, Guid TypeID, Int32 GroupNumber)
        {
            return _context.DALContext.ReportsDAL.GroupAttendancesReport(CourseID, TypeID, GroupNumber);
        }

        public IEnumerable<CompleteGroupGradesReport> GroupGradesReport(Guid CourseID, Guid TypeID, Int32 GroupNumber)
        {
            IEnumerable<GroupGradesReport> query_res = _context.DALContext.ReportsDAL.GroupGradesReport(CourseID, TypeID, GroupNumber);
            List<CompleteGroupGradesReport> result = new List<CompleteGroupGradesReport>();

            for (int i=0; i<=10; i++)
            {
                CompleteGroupGradesReport rep = new CompleteGroupGradesReport();
                rep.RoundValue = i;
                rep.GradesCount = 0;

                result.Add(rep);
            }

            foreach (GroupGradesReport grade in query_res)
            {
                CompleteGroupGradesReport completeReport = result.Where((report, idx) => Math.Round(grade.Grade) == report.RoundValue).First();
                completeReport.GradesCount++;
            }

            return result;
        }
        #endregion
    }
}
