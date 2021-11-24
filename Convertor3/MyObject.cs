using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;
using System.Threading.Tasks;

namespace Convertor3
{
    public class MyObject
    {
        [JsonExtensionData]
        public IDictionary<string, JToken> _additionalData;
    }
}
