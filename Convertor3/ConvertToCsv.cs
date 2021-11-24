using CsvHelper;
using System.Globalization;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.ComponentModel;
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
                //sep = "sep=,";
            //else
            //    sep = "sep=" + sep;

            //var fs = new FileStream(path, FileMode.Create);

            //using (var streamWriter = new StreamWriter(fs, encoding))
            //{
            //    streamWriter.WriteLine(sep);

            //    using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            //    {
            //        csvWriter.WriteRecords(objects);
            //    }
            //}

            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnsNames = objects.Columns.Cast<DataColumn>().Select(column => column.ColumnName);

            sb.AppendLine(string.Join(sep, columnsNames));

            foreach(DataRow row in objects.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(sep, fields));
            }

            File.WriteAllText(path, sb.ToString());




            //StreamWriter streamWriter = new StreamWriter(path, false);

            //foreach(var item in objects.Columns)
            //{
            //    streamWriter.Write(item);

            //    if()
            //}
        }
    }
}
