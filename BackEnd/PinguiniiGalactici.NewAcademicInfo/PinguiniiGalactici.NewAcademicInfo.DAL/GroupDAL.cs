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
    public class GroupDAL : DALObject
    {
        #region Constructors
        public GroupDAL(DALContext context) : base(context) { }
        private static string tableName = "Table5";
        #endregion

        #region Methods
        public IEnumerable<Group> ReadAll()
        {
            return DbOperations.ExecuteQuery<Group>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadAll");
        }

        //aka ReadByID for the other models
        public Group ReadById(Int32 groupNumber)
        {
            Console.WriteLine(groupNumber);
            return DbOperations.ExecuteQuery<Group>(_context.CONNECTION_STRING, "dbo." + tableName + "_ReadByID", new SqlParameter("GroupNumber", groupNumber)).FirstOrDefault();
        }

        public void Insert(Group group)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Insert", group.GenerateSqlParametersFromModel().ToArray());
        }

        public void Update(Group group)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Update", group.GenerateSqlParametersFromModel().ToArray());
        }

        public void Delete(Int32 groupNumber)
        {
            DbOperations.ExecuteCommand(_context.CONNECTION_STRING, "dbo." + tableName + "_Delete", new SqlParameter("GroupNumber", groupNumber));
        }
        #endregion
    }
}
