using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.DAL.Core
{
    public class DALObject : IDisposable
    {
        #region Members
        protected DALContext _context;
        #endregion

        #region Constructors
        public DALObject(DALContext context)
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
            {
                return;
            }
            if (_context != null)
            {
                _context = null;
            }
        }

        ~DALObject()
        {
            Dispose(false);
        }
        #endregion
    }
}
