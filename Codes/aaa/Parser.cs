using System.Text;

namespace Assembler
{
    public class Parser
    {
        /// <summary>
        /// Удаляет все комментарии и пустые строки из программы. Удаляет все пробелы из команд.
        /// </summary>
        /// <param name="asmLines">Строки ассемблерного кода</param>
        /// <returns>Только значащие строки строки ассемблерного кода без комментариев и лишних пробелов</returns>
        public  string[] RemoveWhitespacesAndComments(string[] asmLines)
        {
            var answers = new List<string>();

            foreach (string line in asmLines)
            {
                var stringBuilder = new StringBuilder();
                var formate_line = line.Split("//");

                for (var index = 0; index < formate_line[0].Length; index++)
                    if (formate_line[0][index] != ' ')
                        stringBuilder.Append(formate_line[0][index]);

                if (!string.IsNullOrEmpty(stringBuilder.ToString()))
                    answers.Add(stringBuilder.ToString());
            }

            return answers.ToArray();
        }
    }
}
