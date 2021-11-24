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

            var jsonPath = string.Empty;
            var csvPath = string.Empty;
            var separator = string.Empty;
            var encoding = Encoding.Default;
            var que = string.Empty;

            OptionSet CmdParser = new OptionSet
            {
                {"i|jsonPath=", "JsonPath", jp => jsonPath = jp },
                {"o|csvPath=", "CsvPath", cp => csvPath = cp },
                {"s|separator=", "Separator", sp => separator = sp},
                {"e|encoding=", "Encoding",  en => encoding = Encoding.GetEncoding(en) },
                {"q|que=", "Que", q => que = q }
            };

            try
            {
                List<string> Args = CmdParser.Parse(args);
                if (Args.Count > 1)
                {
                    Console.Write($"Unrecognised argument in: {string.Join(" ", Args)}");
                }
            }
            catch (OptionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (csvPath == string.Empty)
            {
                csvPath = Path.Combine(Path.GetDirectoryName(jsonPath) + Path.GetFileNameWithoutExtension(jsonPath) + ".csv");
            }

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
