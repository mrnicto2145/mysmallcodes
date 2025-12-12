using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Security;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Assembler
{    
    public class HackTranslator
    {
        private int count_variables = 15; 
        public Dictionary<string, string> JumpTable { get; } = new Dictionary<string, string>()
        {
            { "null", "000" }, { "JGT", "001" }, { "JEQ", "010" }, { "JGE", "011" },
            { "JLT", "100" }, { "JNE", "101" }, { "JLE", "110" }, { "JMP", "111" }
        };

        public Dictionary<string, string> DestTable { get; } = new Dictionary<string, string>()
        {
            { "null", "000" }, { "M", "001" }, { "D", "010" }, { "MD", "011" },
            { "A", "100" }, { "AM", "101" }, { "AD", "110" }, { "AMD", "111" }
        };


        public Dictionary<string, string> CompTable { get; } = new Dictionary<string, string>()
        {
            { "0", "0101010" }, { "1", "0111111" }, { "-1", "0111010" }, { "D", "0001100" },
            { "A", "0110000" }, { "M", "1110000" }, { "!D", "0001101" }, { "!A", "0110001" },
            { "!M", "1110001" }, { "-D", "0001111" }, { "-A", "0110011" }, { "-M", "1110011" },
            { "D+1", "0011111" }, { "A+1", "0110111" }, { "M+1", "1110111" }, { "D-1", "0001110" },
            { "A-1", "0110010" }, { "M-1", "1110010" }, { "D+A", "0000010" }, { "D+M", "1000010" },
            { "D-A", "0010011" }, { "D-M", "1010011" }, { "A-D", "0000111" }, { "M-D", "1000111" },
            { "D&A", "0000000" }, { "D&M", "1000000" }, { "D|A", "0010101" }, { "D|M", "1010101" }
        };


        public string[] TranslateAsmToHack(string[] instructions, Dictionary<string, int> symbolTable)
        {
            var result = new List<string>();
            foreach (var instruction in instructions){
                if (instruction[0] == '@')
                    result.Add(AInstructionToCode(instruction, symbolTable));
                else
                    result.Add(CInstructionToCode(instruction));
            }
            return result.ToArray();
        }

       
        public string AInstructionToCode(string aInstruction, Dictionary<string, int> symbolTable)
        {
            var binString2 = new StringBuilder();
            var instruction = aInstruction.Substring(1);

            if (!Regex.IsMatch(instruction, @"[a-zA-Z]"))
                binString2.Append(Convert.ToString(Convert.ToInt32(instruction), 2).PadLeft(16, '0'));
            else{
                if (symbolTable.ContainsKey(instruction))
                    binString2.Append(Convert.ToString(symbolTable[instruction], 2).PadLeft(16, '0'));
                else{
                    count_variables ++;
                    symbolTable[instruction] = count_variables;
                    binString2.Append(Convert.ToString(symbolTable[instruction], 2).PadLeft(16, '0'));
                }
            }
               
            return binString2.ToString();
        }


        public string CInstructionToCode(string cInstruction)
        {
            var binString2 = new StringBuilder("111");
            string compPart = "", destPart = "000", jumpPart = "000";
            if (cInstruction.Contains(';'))
            {
                var parts = cInstruction.Split(';');
                jumpPart = JumpTable[parts[1]];
                var leftParts = parts[0].Split('=');
                var tmp  = leftParts.Length == 2 ? leftParts[1] : leftParts[0];
                compPart = CompTable[tmp];
                destPart = leftParts.Length == 2 ? DestTable[leftParts[0]] : "000";
            }
            else
            {
                var parts = cInstruction.Split('=');
                compPart = CompTable[parts[1]];
                destPart = DestTable[parts[0]];
            }
            binString2.Append(compPart);
            binString2.Append(destPart);
            binString2.Append(jumpPart);
            return binString2.ToString();
        }
    }
}

