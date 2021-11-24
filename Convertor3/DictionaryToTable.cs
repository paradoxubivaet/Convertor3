using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor3
{
    public class DictionaryToTable
    {
        public DataTable DictionariesTotabe(List<Dictionary<string, JToken>> list)
        {
            DataTable dataTable = new DataTable();

            var columnsNames = list.SelectMany(dict => dict.Keys).Distinct();
            dataTable.Columns.AddRange(columnsNames.Select(c => new DataColumn(c)).ToArray());

            foreach(Dictionary<string, JToken> item in list)
            {
                var row = dataTable.NewRow();
                foreach(var key in item.Keys)
                {
                    row[key] = item[key];
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
