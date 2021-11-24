﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Dynamic;
using System.IO;

namespace Convertor3
{
    public class ConvertFromJson : IConvertFrom
    {
        public List<dynamic> Convert(string path)
        {
            List<dynamic> list = JsonConvert.DeserializeObject<List<dynamic>>(File.ReadAllText(path));
            return list;
        }
    }
}
