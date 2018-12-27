using PinguiniiGalactici.NewAcademicInfo.DAL.Core;
using PinguiniiGalactici.NewAcademicInfo.Library;
using PinguiniiGalactici.NewAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.DAL
{
    public class GradeTypeDAL : DALObject
    {
        #region Constructors
        public GradeTypeDAL(DALContext context) : base(context) { }
        private static string tableName = "Table7";
        #endregion

        #region Methods
        public IEnumerable<Models.GradeType> ReadAll()
        {
            return DbOperations.ExecuteQuery<Models.GradeType>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAll");
        }

        //aka ReadByID for the other models
        public GradeType ReadById(Guid TypesID)
        {
            return DbOperations.ExecuteQuery<GradeType>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByID", new SqlParameter("TypeID", TypesID)).FirstOrDefault();
        }

        public void Insert(Models.GradeType Types)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Insert", Types.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(Models.GradeType Types)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Update", Types.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(Guid TypesID)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Delete", new SqlParameter("TypeID", TypesID));
        }
        #endregion
    }
}
