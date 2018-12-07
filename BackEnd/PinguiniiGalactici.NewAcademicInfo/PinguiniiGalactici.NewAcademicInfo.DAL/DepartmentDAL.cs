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
    public class DepartmentDAL : DALObject
    {
        #region Constructors
        public DepartmentDAL(DALContext context) : base(context) { }
        private static string tableName = "Table6";
        #endregion

        #region Methods
        public IEnumerable<Department> ReadAll()
        {
            return DbOperations.ExecuteQuery<Department>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAll");
        }

        //aka ReadByID for the other models
        public Department ReadById(Guid departmentID)
        {
            return DbOperations.ExecuteQuery<Department>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByID", new SqlParameter("DepartmentID", departmentID)).FirstOrDefault();
        }

        public void Insert(Department department)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Insert", department.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(Department department)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Update", department.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(Guid departmentID)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Delete", new SqlParameter("DepartmentID", departmentID));
        }
        #endregion
    }
}
