using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Convertor3
{
    interface IConvertTo
    {
        void Convert(DataTable objects, string path, string sep, Encoding encoding);
    }
}
