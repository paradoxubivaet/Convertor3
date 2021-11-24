using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Convertor3
{
    interface IConvertFrom
    {
        List<dynamic> Convert(string path);
    }
}
