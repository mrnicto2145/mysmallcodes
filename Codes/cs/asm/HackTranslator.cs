using System.Collections.Generic;
using System.Linq;
using System;
using NuGet.Frameworks;
using System.Reflection.Metadata;

namespace Assembler
{

    public class HackTranslator
    {
        /// <summary>
        /// Транслирует инструкции ассемблерного кода (без меток) в бинарное представление.
        /// </summary>
        /// <param name="instructions">Ассемблерный код без меток</param>
        /// <param name="symbolTable">Таблица символов</param>
        /// <returns>Строки инструкций в бинарном формате</returns>
        /// <exception cref="FormatException">Ошибка трансляции</exception> 
        private int freeSpaceNum = 16;
        public string[] TranslateAsmToHack(string[] instructions, Dictionary<string, int> symbolTable)
        {
            var hackInstr = new List<string>();
            foreach(var inst in instructions)
            {
                var code = inst[0] == '@' ? AInstructionToCode(inst, symbolTable): CInstructionToCode(inst);
                if (code == "-1")
                    throw new Exception("Ошибка трансляции");
                else
                    hackInstr.Add(code);                        
            }
            return hackInstr.ToArray();
        }

        /// <summary>
        /// Транслирует одну A-инструкцию ассемблерного кода в бинарное представление
        /// </summary>
        /// <param name="aInstruction">Ассемблерная A-инструкция, например, @42 или @SCREEN</param>
        /// <param name="symbolTable">Таблица символов</param>
        /// <returns>Строка, содержащее нули и единицы — бинарное представление ассемблерной инструкции, например, "0000000000000101"</returns>
        public string AInstructionToCode(string aInstruction, Dictionary<string, int> symbolTable)
        {
            var knownSymbols = symbolTable.Keys;
            var label = aInstruction.Substring(1);
            var value = 0;
            if (knownSymbols.Contains(label))
                value = symbolTable[label];
            else
            {
                if (!int.TryParse(label, out value))
                {
                    symbolTable.Add(label, freeSpaceNum);
                    value = freeSpaceNum;
                    freeSpaceNum++;        
                }
            }
            var binValue = Convert.ToString(value,2);
            return binValue.PadLeft(16,'0');           
        }

        /// <summary>
        /// Транслирует одну C-инструкцию ассемблерного кода в бинарное представление
        /// </summary>
        /// <param name="cInstruction">Ассемблерная C-инструкция, например, A=D+M</param>
        /// <returns>Строка, содержащее нули и единицы — бинарное представление ассемблерной инструкции, например, "1111000010100000"</returns>
        public string CInstructionToCode(string cInstruction)
        {
            var dest = GetDestination(cInstruction);
            var jump = GetJump(cInstruction);
            var acomp = GetCompAndA(cInstruction);
            //if (jump =="-1" || acomp=="-1") return "-1";
            return "111"+acomp+dest+jump;
        }

        public string GetDestination(string inst)
        {
            if (inst.Contains("="))
            {
                var i=inst.IndexOf("=");
                var d = inst.Substring(0,i);
                var dest = "";
                dest += d.Contains('A') ? '1' : '0';
                dest += d.Contains('D') ? '1' : '0';
                dest += d.Contains('M') ? '1' : '0';
                return dest;
            }
            return "000";
        }   

        public static Dictionary<string,string> Jumps = new Dictionary<string, string>
        {
          {"","000"},
          {"JGT","001"},
          {"JEQ","010"},
          {"JGE","011"},
          {"JLT","100"},
          {"JNE","101"},
          {"JLE","110"},
          {"JMP","111"},
        };

        public string GetJump(string inst)
        {
            if (inst.Contains(';'))
            {
                var i = inst.IndexOf(';');
                var d = inst.Substring(i+1,3);
                if (!Jumps.Keys.Contains(d)) return "-1";
                return Jumps[d];
            }
            return "000";
        }

        public static Dictionary<string,string> Comps = new Dictionary<string, string>
        {
          {"0","101010"},
          {"1","111111"},
          {"-1","111010"},
          {"D","001100"},
          {"A","110000"},
          {"!D","001101"},
          {"!A","110001"},
          {"-D","001111"},
          {"-A","110011"},
          {"D+1","011111"},
          {"A+1","110111"},
          {"D-1","001110"},
          {"A-1","110010"},
          {"D+A","000010"},
          {"D-A","010011"},
          {"A-D","000111"},
          {"D&A","000000"},
          {"D|A","010101"}
        };

        public string GetCompAndA(string inst)
        {
            var d = CutComp(inst);
            var a = d.Contains('M') ? '1' : '0';
            d = d.Replace('M','A');
            if (!Comps.Keys.Contains(d)) return "-1";
            var comp = Comps[d];
            return a+comp;
        }

        public string CutComp(string inst)
        {
            var d = inst;
            if (d.Contains(';'))
            {
                var i = d.IndexOf(';');
                d = d.Substring(0,i);
            }
            if (d.Contains('='))
            {
                var i = d.IndexOf('=');
                d = d.Substring(i+1);
            }
            return d;
        }
    }
}
