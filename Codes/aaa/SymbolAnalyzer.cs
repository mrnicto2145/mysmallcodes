using System;
using System.Collections.Generic;

namespace Assembler
{
    public class SymbolAnalyzer
    {
		public Dictionary<string, int> CreateSymbolsTable(string[] instructionsWithLabels,
 out string[] instructionsWithoutLabels)
        {
            var tableSymbol = InitializeSymbolTable();
            var result = ProcessInstructions(instructionsWithLabels, tableSymbol);
            instructionsWithoutLabels = result.ToArray();
            return tableSymbol;
        }

        private Dictionary<string, int> InitializeSymbolTable()
        {
            var registers = new string[] 
            {
                "R0", "R1", "R2", "R3", "R4", "R5", "R6", "R7",
                "R8", "R9", "R10", "R11", "R12", "R13", "R14", "R15"
            };
            var dict = new Dictionary<string, int>(){
                {"SCREEN", 0x4000 }, { "KBD", 0x6000 },
                {"SP", 0 }, { "LCL", 1 }, { "ARG", 2 }, 
                {"THIS", 3 }, { "THAT", 4 }};
            for (int i = 0; i < registers.Length; i++)
                dict.Add(registers[i], i);
            return dict;
        }

        private List<string> ProcessInstructions(string[] instructionsWithLabels, Dictionary<string, int> tableSymbol)
        {
            var result = new List<string>();
            var lineNumber = 0;
            foreach (var instruction in instructionsWithLabels)
            {
                var trimmedInstruction = instruction.Trim();
                if (trimmedInstruction.StartsWith("(") && trimmedInstruction.EndsWith(")"))
                {
                    var label = trimmedInstruction.Substring(1, trimmedInstruction.Length - 2);
                    if (!tableSymbol.ContainsKey(label))
                        tableSymbol[label] = lineNumber;
                }
                else
                {
                    result.Add(trimmedInstruction);
                    lineNumber++;
                }
            }

            return result;
        }
    }
}
