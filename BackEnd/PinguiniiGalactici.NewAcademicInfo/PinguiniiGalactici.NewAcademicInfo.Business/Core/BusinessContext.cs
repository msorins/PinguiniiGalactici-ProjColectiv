using PinguiniiGalactici.NewAcademicInfo.DAL.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business.Core
{
    public class BusinessContext : IDisposable
    {
        #region Members
        private User _currentUser;
        private DALContext _dalContext;

        private UserBusiness _userBusiness;
        private FacultyBusiness _facultyBusiness;
        private DepartmentBusiness _departmentBusiness;
        private GroupBusiness _groupBusiness;
        private AttendanceBusiness _attendancesBusiness;
        private CourseBusiness _coursesBusiness;
        private StudentBusiness _studentsBusiness;
        private StudentCourseBusiness _studentCourseBusiness;
        private TeacherBusiness _teachersBusiness;
        private GradeTypeBusiness _typesBusiness;
        private ReportsBusiness _reportsBusiness;
        #endregion

        #region Constructor
        public BusinessContext() { }

        public BusinessContext(User authenticatedUser)
        {
            _currentUser = authenticatedUser;
            DALContext.InitializeConnectionString(authenticatedUser.Username,authenticatedUser.Password);
        }
        #endregion

        #region Properties
        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
        }

        public DALContext DALContext
        {
            get
            {
                if (_dalContext == null)
                {
                    _dalContext = new DALContext();
                }
                return _dalContext;
            }
        }

        public UserBusiness UserBusiness
        {
            get
            {
                if (_userBusiness == null)
                {
                    _userBusiness = new UserBusiness(this);
                }
                return _userBusiness;
            }
        }
        public FacultyBusiness FacultyBusiness
        {
            get
            {
                if (_facultyBusiness == null)
                {
                    _facultyBusiness = new FacultyBusiness(this);
                }
                return _facultyBusiness;
            }
        }
        public DepartmentBusiness DepartmentBusiness
        {
            get
            {
                if (_departmentBusiness == null)
                {
                    _departmentBusiness = new DepartmentBusiness(this);
                }
                return _departmentBusiness;
            }
        }
        public GroupBusiness GroupBusiness
        {
            get
            {
                if (_groupBusiness == null)
                {
                    _groupBusiness = new GroupBusiness(this);
                }
                return _groupBusiness;
            }
        }
        public AttendanceBusiness AttendancesBusiness
        {
            get
            {
                if (_attendancesBusiness == null)
                {
                    _attendancesBusiness = new AttendanceBusiness(this);
                }
                return _attendancesBusiness;
            }
        }
        public CourseBusiness CoursesBusiness
        {
            get
            {
                if (_coursesBusiness == null)
                {
                    _coursesBusiness = new CourseBusiness(this);
                }
                return _coursesBusiness;
            }
        }
        public StudentBusiness StudentsBusiness
        {
            get
            {
                if (_studentsBusiness == null)
                {
                    _studentsBusiness = new StudentBusiness(this);
                }
                return _studentsBusiness;
            }
        }
        public StudentCourseBusiness StudentCourseBusiness
        {
            get
            {
                if (_studentCourseBusiness == null)
                {
                    _studentCourseBusiness = new StudentCourseBusiness(this);
                }
                return _studentCourseBusiness;
            }
        }
        
        public TeacherBusiness TeachersBusiness
        {
            get
            {
                if (_teachersBusiness == null)
                {
                    _teachersBusiness = new TeacherBusiness(this);
                }
                return _teachersBusiness;
            }
        }
        public GradeTypeBusiness TypesBusiness
        {
            get
            {
                if (_typesBusiness == null)
                {
                    _typesBusiness = new GradeTypeBusiness(this);
                }
                return _typesBusiness;
            }
        }

        public ReportsBusiness ReportsBusiness
        {
            get
            {
                if (_reportsBusiness == null)
                {
                    _reportsBusiness = new ReportsBusiness(this);
                }
                return _reportsBusiness;
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

            DisposeBusinessObject(_userBusiness);
            DisposeBusinessObject(_attendancesBusiness);
            DisposeBusinessObject(_coursesBusiness);
            DisposeBusinessObject(_departmentBusiness);
            DisposeBusinessObject(_facultyBusiness);
            DisposeBusinessObject(_groupBusiness);
            DisposeBusinessObject(_studentCourseBusiness);
            DisposeBusinessObject(_studentsBusiness);
            DisposeBusinessObject(_teachersBusiness);
            DisposeBusinessObject(_typesBusiness);
            DisposeBusinessObject(_reportsBusiness);

            if (_dalContext != null)
            {
                _dalContext.Dispose();
                _dalContext = null;
            }
        }

        private void DisposeBusinessObject(BusinessObject businessObject)
        {
            if (businessObject != null)
            {
                businessObject.Dispose();
                businessObject = null;
            }
        }

        ~BusinessContext()
        {
            Dispose(false);
        }
        #endregion
    }
}
