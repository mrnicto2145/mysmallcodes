using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace Assembler
{
    public class SymbolAnalyzer
    {
        /// <summary>
        /// Находит все метки в ассемблерном коде, удаляет их из кода и вносит их адреса в таблицу символов.
        /// </summary>
        /// <param name="instructionsWithLabels">Ассемблерный код, возможно, содержащий метки</param>
        /// <param name="instructionsWithoutLabels">Ассемблерный код без меток</param>
        /// <returns>
        /// Таблица символов, содержащая все стандартные предопределенные символы (R0−R15, SCREEN, ...),
        /// а также все найденные в программе метки.
        /// </returns>
        public Dictionary<string, int> PreloadSymbolsTable()
        {
            var symbolsTable = new Dictionary<string, int>();
            for (var i = 0; i < 16; i++)
            {
                symbolsTable.Add($"R{i}",i);
            }
            symbolsTable.Add("SCREEN",16384);
            symbolsTable.Add("KBD", 24576);
            symbolsTable.Add("SP", 0);
            symbolsTable.Add("LCL",1);
            symbolsTable.Add("ARG", 2);
            symbolsTable.Add("THIS", 3);
            symbolsTable.Add("THAT", 4);
            return symbolsTable;
        }

        public Dictionary<string, int> FindJumpMarks(string[] instructions)
        {
            var jumpMarks = new Dictionary<string, int>();
            var actualLine = 0;
            foreach (var inst in instructions)
            {
                if (inst[0] == '(')
                {
                    var knownSymbolic = jumpMarks.Keys;
                    var label = inst.Substring(1,inst.Length - 2);
                    if (!knownSymbolic.Contains(label))
                        jumpMarks.Add(label, actualLine);
                    else
                        jumpMarks[label] = actualLine;
                }
                else actualLine++;                   
            }
            return jumpMarks;
        }

        public Dictionary<string, int> FindVariables(string[] instructions, Dictionary<string,int> defTable)
        {
            var variables = new Dictionary<string, int>();
            var freeSpaceNum = 16;
            foreach (var inst in instructions)
            {
                if (inst[0] == '@')
                {
                    var knownKeys = defTable.Keys;
                    var knownVariables = variables.Keys;
                    var label = inst.Substring(1,inst.Length - 1);
                    if (int.TryParse(label, out var value)|| knownKeys.Contains(label)) continue;
                    else
                    {
                        if (!knownVariables.Contains(label))
                        {
                            variables.Add(label, freeSpaceNum);
                            freeSpaceNum++;
                        }
                    }
                }                  
            }
            return variables;
        } 

        public Dictionary<string, int> CreateSymbolsTable(string[] instructionsWithLabels,
            out string[] instructionsWithoutLabels)
        {
            var symbolsTable = PreloadSymbolsTable();
            var insWithoutLabels = new List<string>();          
            var jumps = FindJumpMarks(instructionsWithLabels);
            foreach (var key in jumps.Keys)
                if (!symbolsTable.Keys.Contains(key))
                    symbolsTable.Add(key, jumps[key]);
            var variables = FindVariables(instructionsWithLabels,symbolsTable);
            foreach (var key in variables.Keys)
                    symbolsTable.Add(key, variables[key]);
            foreach (var inst in instructionsWithLabels)
                if (inst[0] != '(')
                    insWithoutLabels.Add(inst);    
            instructionsWithoutLabels = insWithoutLabels.ToArray();
            return symbolsTable;
        }
    }
}
