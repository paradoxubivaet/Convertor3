using NDesk.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Convertor3
{
    class Program
    {
        static void Main(string[] args)
        {
            var parserCml = new ParseCommandLine();
            Dictionary<string, string> dicArgs =  parserCml.Parse(args);

            var jsonPath = dicArgs["-i"];
            var csvPath = dicArgs["-o"];
            var separator = dicArgs["-s"];
            var encoding = Encoding.GetEncoding(dicArgs["-e"]);

            var convertFromJson = new ConvertFromJson();
            DataTable objects = convertFromJson.Convert(jsonPath);

            var convertToCsv = new ConvertToCsv();
            convertToCsv.Convert(objects, csvPath, separator, encoding);

            if (!args.Contains("-q"))
            {
                Console.WriteLine("Программа была успешно выполнена");
                Console.ReadLine();
            }

        }
    }
}
