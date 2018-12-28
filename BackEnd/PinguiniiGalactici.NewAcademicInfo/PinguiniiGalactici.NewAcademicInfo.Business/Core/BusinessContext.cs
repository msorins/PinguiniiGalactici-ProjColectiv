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


        private AttendanceBusiness _AttendancesBusiness;
        private CourseBusiness _CoursesBusiness;
        private StudentBusiness _StudentsBusiness;
        private StudentCourseBusiness _StudentCourseBusiness;
        private TeacherBusiness _TeachersBusiness;
        private GradeTypeBusiness _TypesBusiness;
        #endregion

        #region Constructor
        public BusinessContext() { }

        public BusinessContext(User authenticatedUser)
        {
            _currentUser = authenticatedUser;
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
                if (_AttendancesBusiness == null)
                {
                    _AttendancesBusiness = new AttendanceBusiness(this);
                }
                return _AttendancesBusiness;
            }
        }
        public CourseBusiness CoursesBusiness
        {
            get
            {
                if (_CoursesBusiness == null)
                {
                    _CoursesBusiness = new CourseBusiness(this);
                }
                return _CoursesBusiness;
            }
        }
        public StudentBusiness StudentsBusiness
        {
            get
            {
                if (_StudentsBusiness == null)
                {
                    _StudentsBusiness = new StudentBusiness(this);
                }
                return _StudentsBusiness;
            }
        }
        public StudentCourseBusiness StudentCourseBusiness
        {
            get
            {
                if (_StudentCourseBusiness == null)
                {
                    _StudentCourseBusiness = new StudentCourseBusiness(this);
                }
                return _StudentCourseBusiness;
            }
        }
        
        public TeacherBusiness TeachersBusiness
        {
            get
            {
                if (_TeachersBusiness == null)
                {
                    _TeachersBusiness = new TeacherBusiness(this);
                }
                return _TeachersBusiness;
            }
        }
        public GradeTypeBusiness TypesBusiness
        {
            get
            {
                if (_TypesBusiness == null)
                {
                    _TypesBusiness = new GradeTypeBusiness(this);
                }
                return _TypesBusiness;
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
