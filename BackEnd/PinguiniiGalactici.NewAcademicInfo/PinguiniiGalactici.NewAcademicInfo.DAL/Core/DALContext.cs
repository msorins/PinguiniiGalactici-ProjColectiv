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
