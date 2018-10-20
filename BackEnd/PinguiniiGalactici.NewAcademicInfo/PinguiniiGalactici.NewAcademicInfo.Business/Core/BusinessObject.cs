using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Business.Core
{
    public class BusinessObject : IDisposable
    {
        #region Members
        protected BusinessContext _context;
        #endregion

        #region Constructor
        public BusinessObject(BusinessContext context)
        {
            _context = context;
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
            if (_context != null)
            {
                _context = null;
            }
        }

        ~BusinessObject()
        {
            Dispose(false);
        }
        #endregion
    }
}
