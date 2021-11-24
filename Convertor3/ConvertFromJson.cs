﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Dynamic;
using System.IO;
using System.Data;

namespace Convertor3
{
    public class ConvertFromJson : IConvertFrom
    {
        public DataTable Convert(string path)
        {
            //List<MyObject> list = JsonConvert.DeserializeObject<List<MyObject>>(File.ReadAllText(path));
            //return list;

            List<Dictionary<string, JToken>> list = JsonConvert.DeserializeObject<List<Dictionary<string, JToken>>>(File.ReadAllText(path));

            DictionaryToTable dtt = new DictionaryToTable();
            DataTable dt = dtt.DictionariesTotabe(list);
            return dt;

        }
    }
}
