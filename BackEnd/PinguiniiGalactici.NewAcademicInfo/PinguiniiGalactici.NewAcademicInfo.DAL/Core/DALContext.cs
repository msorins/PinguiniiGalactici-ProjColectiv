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
        private const string SERVER = "DESKTOP-LKES2D6\\SQLEXPRESS";
        string DATABASE = "AcademicInfo";
        #endregion

        #region Members
        internal string CONNECTION_STRING = "";
        private UserDAL _userDAL;
        private FacultyDAL _facultyDAL;
        private DepartmentDAL _departmentDAL;
        private GroupDAL _groupDAL;

        private AttendanceDAL _AttendancesDAL;
        private CoursesDAL _CoursesDAL;
        private StudentDAL _StudentsDAL;
        private StudentCourseDAL _StudentCourseDAL;
        private TeacherDAL _TeachersDAL;
        private GradeTypeDAL _TypesDAL;
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

        public AttendanceDAL AttendancesDAL
        {
            get
            {
                if (_AttendancesDAL == null)
                    _AttendancesDAL = new AttendanceDAL(this);
                return _AttendancesDAL;
            }
        }
        public CoursesDAL CoursesDAL
        {
            get
            {
                if (_CoursesDAL == null)
                    _CoursesDAL = new CoursesDAL(this);
                return _CoursesDAL;
            }
        }

        public StudentDAL StudentsDAL
        {
            get
            {
                if (_StudentsDAL == null)
                    _StudentsDAL = new StudentDAL(this);
                return _StudentsDAL;
            }
        }
        public StudentCourseDAL StudentCourseDAL
        {
            get
            {
                if (_StudentCourseDAL == null)
                    _StudentCourseDAL = new StudentCourseDAL(this);
                return _StudentCourseDAL;
            }
        }
        

        public TeacherDAL TeachersDAL
        {
            get
            {
                if (_TeachersDAL == null)
                    _TeachersDAL = new TeacherDAL(this);
                return _TeachersDAL;
            }
        }
        public GradeTypeDAL TypesDAL
        {
            get
            {
                if (_TypesDAL == null)
                    _TypesDAL = new GradeTypeDAL(this);
                return _TypesDAL;
            }
        }
        #endregion

        #region Methods
        public void InitializeConnectionString(string username, string password)
        {
            this.CONNECTION_STRING = string.Format("Data Source={0};Initial Catalog={1};User id={2};Password={3};", SERVER, DATABASE, username, password);
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
