using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    class FacultyBusiness : BusinessObject
    {
        #region Constructor
        public FacultyBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Faculty faculty)
        {
            _context.DALContext.FacultyDAL.Insert(faculty);
        }

        public Faculty ReadByUsername(Guid facultyID)
        {
            return _context.DALContext.FacultyDAL.ReadByUsername(facultyID);
        }

        public IEnumerable<Faculty> ReadAll()
        {
            return _context.DALContext.FacultyDAL.ReadAll();
        }

        public void Update(Faculty faculty)
        {
            _context.DALContext.FacultyDAL.Update(faculty);
        }

        public void Delete(Guid facultyID)
        {
            _context.DALContext.FacultyDAL.Delete(facultyID);
        }
        #endregion
    }
}
