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
        public IEnumerable<AverageGradeReport> AverageGradesReport(Guid CourseID, String TypeName)
        {
            return _context.DALContext.ReportsDAL.AverageGradesReport(CourseID, TypeName);
        }
        public IEnumerable<PassingGradesReport> PassingGradesReport(Guid CourseID, String TypeName)
        {
            return _context.DALContext.ReportsDAL.PassingGradesReport(CourseID, TypeName);
        }
        #endregion
    }
}
