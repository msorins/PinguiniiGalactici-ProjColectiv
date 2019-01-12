using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class StudentBusiness : BusinessObject
    {
        #region Constructor
        public StudentBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Student Students)
        {
            _context.DALContext.StudentsDAL.Insert(Students);
        }

        public Student ReadById(Int32 StudentsID)
        {
            return _context.DALContext.StudentsDAL.ReadById(StudentsID);
        }

        public IEnumerable<Student> ReadAll()
        {
            return _context.DALContext.StudentsDAL.ReadAll();
        }

        public IEnumerable<Student> ReadAllFromCourse(Guid courseId)
        {
            return _context.DALContext.StudentsDAL.ReadAllFromCourse(courseId);
        }

        public void MoveToGroup(Int32 group, List<Int32> students)
        {
            foreach (Int32 sid in students)
            {
                Student s = _context.DALContext.StudentsDAL.ReadById(sid);
                s.GroupNumber = group;
                _context.DALContext.StudentsDAL.Update(s);
            }
        }

        public void Update(Student Students)
        {
            _context.DALContext.StudentsDAL.Update(Students);
        }

        public void Delete(Int32 StudentsID)
        {
            _context.DALContext.StudentsDAL.Delete(StudentsID);
        }

        public void AddBulk(List<Student> students)
        {
            foreach (Student student in students)
                Insert(student);
        }
        #endregion
    }
}
