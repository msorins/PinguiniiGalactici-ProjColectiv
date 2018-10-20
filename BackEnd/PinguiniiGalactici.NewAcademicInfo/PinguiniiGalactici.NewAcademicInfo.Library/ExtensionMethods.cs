using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PinguiniiGalactici.NewAcademicInfo.Library
{
    public static class ExtensionMethods
    {
        #region Methods
        public static T GetObjectFromReader<T>(this SqlDataReader reader) where T : new()
        {
            T element = new T();
            Type type = element.GetType();
            List<PropertyInfo> typeProperties = type.GetProperties().ToList();

            foreach (PropertyInfo property in typeProperties)
            {
                DataMemberAttribute attribute = property.GetCustomAttributes(typeof(DataMemberAttribute), true).FirstOrDefault() as DataMemberAttribute;

                if (attribute.Name == null || Convert.IsDBNull(reader[attribute.Name]))
                {
                    continue;
                }
                property.SetValue(element, reader[attribute.Name], null);
            }
            return element;
        }

        public static List<SqlParameter> GenerateSqlParametersFromModel<T>(this T model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                DataMemberAttribute attribute = property.GetCustomAttributes(typeof(DataMemberAttribute), true).FirstOrDefault() as DataMemberAttribute;

                if (attribute.Name == null || property.GetValue(model) == null)
                {
                    continue;
                }
                parameters.Add(new SqlParameter(BuildParameterName(attribute.Name), property.GetValue(model)));
            }
            return parameters;
        }

        private static string BuildParameterName(string parameterName)
        {
            return String.Format("@{0}", parameterName);
        }
        #endregion
    }
}
