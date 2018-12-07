using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class DepartmentBusiness : BusinessObject
    {
        #region Constructor
        public DepartmentBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Department department)
        {
            _context.DALContext.DepartmentDAL.Insert(department);
        }

        public Department ReadById(Guid departmentID)
        {
            return _context.DALContext.DepartmentDAL.ReadById(departmentID);
        }

        public IEnumerable<Department> ReadAll()
        {
            return _context.DALContext.DepartmentDAL.ReadAll();
        }

        public void Update(Department department)
        {
            _context.DALContext.DepartmentDAL.Update(department);
        }

        public void Delete(Guid departmentID)
        {
            _context.DALContext.DepartmentDAL.Delete(departmentID);
        }
        #endregion
    }
}
