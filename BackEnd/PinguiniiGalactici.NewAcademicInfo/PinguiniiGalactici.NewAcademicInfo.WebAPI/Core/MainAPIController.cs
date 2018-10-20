using PinguiniiGalactici.NewAcademicInfo.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PinguiniiGalactici.NewAcademicInfo.WebAPI.Core
{
    public class MainAPIController : ApiController
    {
        #region Members
        private BusinessContext _businessContext;
        #endregion

        #region Properties
        public BusinessContext BusinessContext
        {
            get
            {
                if (_businessContext == null)
                {
                    _businessContext = new BusinessContext();
                }
                return _businessContext;
            }
        }
        #endregion

        #region IDisposable
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_businessContext != null)
                {
                    _businessContext.Dispose();
                    _businessContext = null;
                }
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
