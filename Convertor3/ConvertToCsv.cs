using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Convertor3
{
    public class ConvertToCsv
    {
        public void Convert(DataTable objects, string path, string sep, Encoding encoding)
        {
            if (sep == string.Empty)
                sep = ",";

            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnsNames = objects.Columns.Cast<DataColumn>().Select(column => column.ColumnName);

            sb.AppendLine(string.Join(sep, columnsNames));

            foreach(DataRow row in objects.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(sep, fields));
            }

            File.WriteAllText(path, sb.ToString(), encoding);
        }
    }
}
