using PinguiniiGalactici.NewAcademicInfo.Models.Utils;
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
        internal string CONNECTION_STRING = "";
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

        #region Methods
        internal void InitializeConnectionString(string username, string password)
        {
            string server = "DESKTOP-B05EV29";
            string databaseName = "AcademicInfo";

            this.CONNECTION_STRING =  string.Format("Data Source={0};Initial Catalog={1};User id={2};Password={3};", server, databaseName, username, password);
        }
        #endregion

        #region IDisposable Implementation
        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
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
            //Dispose(false);
        }
        #endregion
    }
}
