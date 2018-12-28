using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Models.Utils
{
    public static class ConnectionString
    {
        public static string GetConnectionString(string username, string password)
        {
            string server = "DESKTOP-B05EV29";
            string databaseName = "AcademicInfo";

            return string.Format("Data Source={0};Initial Catalog={1};User id={2};Password={3};",server,databaseName,username,password);
        }
    }
}
