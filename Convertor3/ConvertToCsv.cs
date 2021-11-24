using CsvHelper;
using System.Globalization;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.ComponentModel;

namespace Convertor3
{
    public class ConvertToCsv
    {
        public void Convert(List<dynamic> objects, string path, string sep, Encoding encoding)
        {
            if (sep == string.Empty)
                sep = "sep=,";
            else
                sep = "sep=" + sep;

            var fs = new FileStream(path, FileMode.Create);

            using (var streamWriter = new StreamWriter(fs, encoding))
            {
                streamWriter.WriteLine(sep);

                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(objects);
                }
            }
        }
    }
}
