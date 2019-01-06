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
        private const string SERVER = "MADALINA\\SQLEXPRESS01";
        string DATABASE = "AcademicInfo";
        #endregion

        #region Members
        internal string CONNECTION_STRING = "";
        private UserDAL _userDAL;
        private FacultyDAL _facultyDAL;
        private DepartmentDAL _departmentDAL;
        private GroupDAL _groupDAL;
        private AttendanceDAL _attendancesDAL;
        private CoursesDAL _coursesDAL;
        private StudentDAL _studentsDAL;
        private StudentCourseDAL _studentCourseDAL;
        private TeacherDAL _teachersDAL;
        private GradeTypeDAL _typesDAL;
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
                if (_attendancesDAL == null)
                    _attendancesDAL = new AttendanceDAL(this);
                return _attendancesDAL;
            }
        }
        public CoursesDAL CoursesDAL
        {
            get
            {
                if (_coursesDAL == null)
                    _coursesDAL = new CoursesDAL(this);
                return _coursesDAL;
            }
        }

        public StudentDAL StudentsDAL
        {
            get
            {
                if (_studentsDAL == null)
                    _studentsDAL = new StudentDAL(this);
                return _studentsDAL;
            }
        }
        public StudentCourseDAL StudentCourseDAL
        {
            get
            {
                if (_studentCourseDAL == null)
                    _studentCourseDAL = new StudentCourseDAL(this);
                return _studentCourseDAL;
            }
        }
        
        public TeacherDAL TeachersDAL
        {
            get
            {
                if (_teachersDAL == null)
                    _teachersDAL = new TeacherDAL(this);
                return _teachersDAL;
            }
        }
        public GradeTypeDAL TypesDAL
        {
            get
            {
                if (_typesDAL == null)
                    _typesDAL = new GradeTypeDAL(this);
                return _typesDAL;
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            DisposeDALObject(_userDAL);
            DisposeDALObject(_attendancesDAL);
            DisposeDALObject(_studentsDAL);
            DisposeDALObject(_coursesDAL);
            DisposeDALObject(_departmentDAL);
            DisposeDALObject(_facultyDAL);
            DisposeDALObject(_groupDAL);
            DisposeDALObject(_studentCourseDAL);
            DisposeDALObject(_teachersDAL);
            DisposeDALObject(_typesDAL);
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
