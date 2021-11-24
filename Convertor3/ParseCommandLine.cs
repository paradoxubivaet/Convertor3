using NDesk.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor3
{
    class ParseCommandLine
    {
        public Dictionary<string, string> Parse(string[] args)
        {
            var jsonPath = string.Empty;
            var csvPath = string.Empty;
            var separator = string.Empty;
            var encoding = string.Empty;
            var que = string.Empty;

            OptionSet CmdParser = new OptionSet
            {
                {"i|jsonPath=", "JsonPath", jp => jsonPath = jp },
                {"o|csvPath=", "CsvPath", cp => csvPath = cp },
                {"s|separator=", "Separator", sp => separator = sp},
                {"e|encoding=", "Encoding",  en => encoding = en },
                {"q|que=", "Que", q => que = q }
            };

            try
            {
                List<string> listArgs = CmdParser.Parse(args);
            }
            catch (OptionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (csvPath == string.Empty)
            {
                csvPath = Path.Combine(Path.GetDirectoryName(jsonPath) + Path.GetFileNameWithoutExtension(jsonPath) + ".csv");
            }

            Dictionary<string, string> dicArgs = new Dictionary<string, string>();

            dicArgs.Add("-i", jsonPath);
            dicArgs.Add("-o", csvPath);
            dicArgs.Add("-s", separator);
            dicArgs.Add("-e", encoding);
            dicArgs.Add("-q", que);

            return dicArgs;
        }
    }
}
