using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class CourseBusiness : BusinessObject
    {
        #region Constructor
        public CourseBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Course Courses)
        {
            _context.DALContext.CoursesDAL.Insert(Courses);
        }

        public Course ReadById(Guid CoursesID)
        {
            return _context.DALContext.CoursesDAL.ReadById(CoursesID);
        }

        public IEnumerable<Course> ReadAll()
        {
            return _context.DALContext.CoursesDAL.ReadAll();
        }

        public void Update(Course Courses)
        {
            _context.DALContext.CoursesDAL.Update(Courses);
        }

        public void Delete(Guid CoursesID)
        {
            _context.DALContext.CoursesDAL.Delete(CoursesID);
        }

        public IEnumerable<Course> ReadAllForTeacher(Guid TeacherID)
        {
            return _context.DALContext.CoursesDAL.ReadAllForTeacher(TeacherID);
        }
        #endregion
    }
}
