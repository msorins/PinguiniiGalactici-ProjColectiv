using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business
{
    public class GradeTypeBusiness : BusinessObject
    {
        #region Constructor
        public GradeTypeBusiness(BusinessContext context) : base(context) { }
        #endregion

        #region Methods
        public void Insert(Models.GradeType Types)
        {
            _context.DALContext.TypesDAL.Insert(Types);
        }

        public GradeType ReadById(Guid TypesID)
        {
            return _context.DALContext.TypesDAL.ReadById(TypesID);
        }

        public IEnumerable<Models.GradeType> ReadAll()
        {
            return _context.DALContext.TypesDAL.ReadAll();
        }

        public void Update(Models.GradeType Types)
        {
            _context.DALContext.TypesDAL.Update(Types);
        }

        public void Delete(Guid TypesID)
        {
            _context.DALContext.TypesDAL.Delete(TypesID);
        }
        #endregion
    }
}
