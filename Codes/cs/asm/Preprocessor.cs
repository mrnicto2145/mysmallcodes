using System.Collections.Generic;
using System.Linq;
using System;
using System.Formats.Asn1;
using Microsoft.VisualBasic;

namespace Assembler
{
    public class Preprocessor
    {
        /// <summary>
        /// Преобразует нестандартные макро-инструкции в инструкции обычного языка ассемблера.
        /// </summary>
        private string[] Jumps = new []{"JGT","JEQ","JGE","JLT","JNE","JLE","JMP"};
        public string[] PreprocessAsm(string[] instructions)
        {
            var asmCode = new List<string>();
            for (int i = 0; i < instructions.Length; i++)
            {
                var instr = instructions[i];
                try
                {
                    TranslateInstruction(instr, asmCode);
                }
                catch (Exception e)
                {
                    throw new FormatException($"Can't parse at line {i + 1}: {instr}", e);
                }
            }

            return asmCode.ToArray();
        }

        public void TranslateInstruction(string instruction, List<string> asmCode)
        {
            if (instruction[0] == '@')
            {
                asmCode.Add(instruction);
            }
            else
            {
                var addr = "";
                var comm = "";
                var flag = false;
                foreach (var symb in instruction)
                {
                    if (symb == '[')
                    {
                        flag = true;
                        addr = "";
                        continue;
                    }
                    else if (symb == ']')
                    {
                        flag = false;
                        continue;
                    }
                    else
                    {
                        if (flag) addr+=symb;
                        else comm+=symb;
                    }
                }
                if (addr != "")
                    asmCode.Add($"@{addr}");
                if (Jumps.Contains(comm))
                {
                    asmCode.Add($"{((comm == "JMP") ? '0':'D')};{comm}");
                }
                else
                {
                    asmCode.Add(comm);
                }
            }
        }
    }
}
