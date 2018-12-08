using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class AttendanceBusiness : BusinessObject
    {
        #region Constructor
        public AttendanceBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Attendance Attendances)
        {
            _context.DALContext.AttendancesDAL.Insert(Attendances);
        }

        public Attendance ReadById(Guid AttendancesID)
        {
            return _context.DALContext.AttendancesDAL.ReadById(AttendancesID);
        }

        public IEnumerable<Attendance> ReadAll()
        {
            return _context.DALContext.AttendancesDAL.ReadAll();
        }

        public void Update(Attendance Attendances)
        {
            _context.DALContext.AttendancesDAL.Update(Attendances);
        }

        public void Delete(Guid AttendancesID)
        {
            _context.DALContext.AttendancesDAL.Delete(AttendancesID);
        }
        #endregion
    }
}
