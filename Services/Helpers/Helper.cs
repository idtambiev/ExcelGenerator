using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class Helper
    {
        public static DataTable GenerateDataTable<T>(List<T> models)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (var model in models)
            {
                var values = new object[properties.Length];

                for (var i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(model, null);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
