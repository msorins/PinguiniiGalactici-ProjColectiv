using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.DAL.Core
{
    public class DALContext : IDisposable
    {
        #region Constants
        internal string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        #endregion

        #region Members
        private UserDAL _userDAL;
        private FacultyDAL _facultyDAL;
        private DepartmentDAL _departmentDAL;
        private GroupDAL _groupDAL;
        #endregion

        #region Properties      
        public UserDAL UserDAL
        {
            get
            {
                if (_userDAL == null)
                    _userDAL = new UserDAL(this);
                return _userDAL;
            }
        }

        public FacultyDAL FacultyDAL
        {
            get
            {
                if (_facultyDAL == null)
                    _facultyDAL = new FacultyDAL(this);
                return _facultyDAL;
            }
        }

        public DepartmentDAL DepartmentDAL
        {
            get
            {
                if (_departmentDAL == null)
                    _departmentDAL = new DepartmentDAL(this);
                return _departmentDAL;
            }
        }

        public GroupDAL GroupDAL
        {
            get
            {
                if (_groupDAL == null)
                    _groupDAL = new GroupDAL(this);
                return _groupDAL;
            }
        }
        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            DisposeDALObject(_userDAL);
        }

        private void DisposeDALObject(DALObject dalObject)
        {
            if (dalObject != null)
            {
                dalObject.Dispose();
                dalObject = null;
            }
        }

        ~DALContext()
        {
            Dispose(false);
        }
        #endregion
    }
}
