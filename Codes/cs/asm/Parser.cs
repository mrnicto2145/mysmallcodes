using System.Runtime.CompilerServices;

namespace Assembler
{
    public class Parser
    {
        /// <summary>
        /// Удаляет все комментарии и пустые строки из программы. Удаляет все пробелы из команд.
        /// </summary>
        /// <param name="asmLines">Строки ассемблерного кода</param>
        /// <returns>Только значащие строки строки ассемблерного кода без комментариев и лишних пробелов</returns>
        public bool IsStartOfCommand(char symbol)
        {
            var startSymbols = "@AMD(01-!".ToArray();
            return startSymbols.Contains(symbol);
        }

        public string RemoveWhitespaces(string line)
        {
            var newLine = "";
            foreach(var i in line)
            {
                if (i != ' ' && i != '\n') newLine += i;
            }
            return newLine;
        }
        
        public string[] RemoveWhitespacesAndComments(string[] asmLines)
        {
            var asmCode = new List<string>();
            var commentSymbols = "#/".ToArray();
            foreach (var spacedLine in asmLines)
            {
                var line = RemoveWhitespaces(spacedLine);
                if (line == "") continue;
                if (IsStartOfCommand(line[0]))
                {
                    var command = "";
                    for(int i = 0; i < line.Length; i++)
                    {
                        if (!commentSymbols.Contains(line[i]))
                            command += line[i];
                        else
                            break;
                    }
                    if (command != "")
                    {
                        asmCode.Add(command);
                    }
                } 
            }
            return asmCode.ToArray();
        }
    }
}
