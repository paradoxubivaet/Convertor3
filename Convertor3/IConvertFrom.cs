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
    interface IConvertFrom
    {
        DataTable Convert(string path);
    }
}
