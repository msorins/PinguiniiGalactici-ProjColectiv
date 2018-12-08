using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class GroupBusiness : BusinessObject
    {
        #region Constructor
        public GroupBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Group group)
        {
            _context.DALContext.GroupDAL.Insert(group);
        }

        public Group ReadById(Int32 groupNumber)
        {
            return _context.DALContext.GroupDAL.ReadById(groupNumber);
        }

        public IEnumerable<Group> ReadAll()
        {
            return _context.DALContext.GroupDAL.ReadAll();
        }

        public void Update(Group group)
        {
            _context.DALContext.GroupDAL.Update(group);
        }

        public void Delete(Int32 groupNumber)
        {
            _context.DALContext.GroupDAL.Delete(groupNumber);
        }
        #endregion
    }
}
