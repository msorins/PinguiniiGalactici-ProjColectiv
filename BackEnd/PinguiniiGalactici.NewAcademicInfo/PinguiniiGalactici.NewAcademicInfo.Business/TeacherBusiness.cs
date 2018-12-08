using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class TeacherBusiness : BusinessObject
    {
        #region Constructor
        public TeacherBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Teacher Teachers)
        {
            _context.DALContext.TeachersDAL.Insert(Teachers);
        }

        public Teacher ReadById(Guid TeachersID)
        {
            return _context.DALContext.TeachersDAL.ReadById(TeachersID);
        }

        public IEnumerable<Teacher> ReadAll()
        {
            return _context.DALContext.TeachersDAL.ReadAll();
        }

        public void Update(Teacher Teachers)
        {
            _context.DALContext.TeachersDAL.Update(Teachers);
        }

        public void Delete(Guid TeachersID)
        {
            _context.DALContext.TeachersDAL.Delete(TeachersID);
        }
        #endregion
    }
}
