using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class StudentCourseBusiness : BusinessObject
    {
        #region Constructor
        public StudentCourseBusiness(BusinessContext context) : base(context) { }
        #endregion

        
        
        #region Methods
        public void Insert(StudentCourse studentCourse)
        {
            _context.DALContext.StudentCourseDAL.Insert(studentCourse);
        }

        public StudentCourse ReadById(Guid enrollementID)
        {
            return _context.DALContext.StudentCourseDAL.ReadById(enrollementID);
        }

        public IEnumerable<StudentCourse> ReadAll()
        {
            return _context.DALContext.StudentCourseDAL.ReadAll();
        }

        public void Update(StudentCourse studentCourse)
        {
            _context.DALContext.StudentCourseDAL.Update(studentCourse);
        }

        public void Delete(Guid enrollementID)
        {
            _context.DALContext.StudentCourseDAL.Delete(enrollementID);
        }
        #endregion
    }
}
