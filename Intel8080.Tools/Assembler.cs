using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Intel8080.Tools
{
    public class Assembler
    {
        public static byte[] Execute(string assemblyCode)
        {
            string[] lines = assemblyCode.Replace("\r", "").Split("\n");

            Dictionary<string, string> labels = new Dictionary<string, string>();

            using (MemoryStream stream = new MemoryStream())
            {

                //parse labels
                foreach (var line in lines)
                {
                    string label = null;
                    string instruction = null;
                    string code = null;
                    string operand = null;

                    if (line.Contains(":"))
                    {
                        var parts = line.Split(":");

                        label = parts[0];
                        labels.Add(label, (stream.Position + 1).ToString("X4"));

                        instruction = parts[1];
                    }
                    else
                    {
                        instruction = line;
                    }

                    var instructionParts = instruction.Trim().Split(" ", 1);

                    code = instructionParts[0];

                    if(instructionParts.Length > 1)
                    {
                        operand = instructionParts[1].Replace(" ", "");
                    }

                    ParseOpCode(stream, code, operand, true);

                }

                return stream.GetBuffer();
            }

        }


        private static void ParseOpCode(Stream stream, string code, string operand, bool preprocess)
        {
            string[] operandParts = operand.Split(",");

            switch (code)
            {
                case "NOP":
                    stream.WriteByte(OpCodes.NOP);
                    break; 
                case "LXI":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.LXI_B);
                        if (preprocess)
                            stream.Write(new byte[] { 0, 0 });
                        else
                            stream.Write(BitConverter.GetBytes(short.Parse(operandParts[1].Trim('H'), System.Globalization.NumberStyles.HexNumber)));
                    }
                    break;
                case "STAX_B":
                    if(operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.STAX_B);
                    }
                    break;
                /*case "INX_B":
                    OpCode(sb, "INX", "B");
                    break;
                case "INR_B":
                    OpCode(sb, "INR", "B");
                    break;
                case "DCR_B":
                    OpCode(sb, "DCR", "B");
                    break;
                case "MVI_B":
                    OpCode8(sb, stream, "MVI", "B");
                    break;
                case "RLC":
                    OpCode(sb, "RLC");
                    break;


                case "DAD_B":
                    OpCode(sb, "DAD", "B");
                    break;
                case "LDAX_B":
                    OpCode(sb, "LDAX", "B");
                    break;
                case "DCX_B":
                    OpCode(sb, "DCX", "B");
                    break;
                case "INR_C":
                    OpCode(sb, "INR", "C");
                    break;
                case "DCR_C":
                    OpCode(sb, "DCR", "C");
                    break;
                case "MVI_C":
                    OpCode8(sb, stream, "MVI", "C");
                    break;
                case "RRC":
                    OpCode(sb, "RRC");
                    break;


                case "LXI_D":
                    OpCode16(sb, stream, "LXI", "D");
                    break;
                case "STAX_D":
                    OpCode(sb, "STAX", "D");
                    break;
                case "INX_D":
                    OpCode(sb, "INX", "D");
                    break;
                case "INR_D":
                    OpCode(sb, "INR", "D");
                    break;
                case "DCR_D":
                    OpCode(sb, "DCR", "D");
                    break;
                case "MVI_D":
                    OpCode8(sb, stream, "MVI", "D");
                    break;
                case "RAL":
                    OpCode(sb, "RAL");
                    break;


                case "DAD_D":
                    OpCode(sb, "DAD", "D");
                    break;
                case "LDAX_D":
                    OpCode(sb, "LDAX", "D");
                    break;
                case "DCX_D":
                    OpCode(sb, "DCX", "D");
                    break;
                case "INR_E":
                    OpCode(sb, "INR", "E");
                    break;
                case "DCR_E":
                    OpCode(sb, "DCR", "E");
                    break;
                case "MVI_E":
                    OpCode8(sb, stream, "MVI", "E");
                    break;
                case "RAR":
                    OpCode(sb, "RAR");
                    break;


                case "LXI_H":
                    OpCode16(sb, stream, "LXI", "H");
                    break;
                case "SHLD":
                    OpCodeAddress(sb, stream, "SHLD");
                    break;
                case "INX_H":
                    OpCode(sb, "INX", "H");
                    break;
                case "INR_H":
                    OpCode(sb, "INR", "H");
                    break;
                case "DCR_H":
                    OpCode(sb, "DCR", "H");
                    break;
                case "MVI_H":
                    OpCode8(sb, stream, "MVI", "H");
                    break;
                case "DAA":
                    OpCode(sb, "DAA");
                    break;


                case "DAD_H":
                    OpCode(sb, "DAD", "H");
                    break;
                case "LHLD":
                    OpCodeAddress(sb, stream, "LHLD");
                    break;
                case "DCX_H":
                    OpCode(sb, "DCX", "H");
                    break;
                case "INR_L":
                    OpCode(sb, "INR", "L");
                    break;
                case "DCR_L":
                    OpCode(sb, "DCR", "L");
                    break;
                case "MVI_L":
                    OpCode8(sb, stream, "MVI", "L");
                    break;
                case "CMA":
                    OpCode(sb, "CMA");
                    break;


                case "LXI_SP":
                    OpCode16(sb, stream, "LXI", "SP");
                    break;
                case "STA":
                    OpCodeAddress(sb, stream, "STA");
                    break;
                case "INX_SP":
                    OpCode(sb, "INX", "SP");
                    break;
                case "INR_M":
                    OpCode(sb, "INR", "M");
                    break;
                case "DCR_M":
                    OpCode(sb, "DCR", "M");
                    break;
                case "MVI_M":
                    OpCode8(sb, stream, "MVI", "M");
                    break;
                case "STC":
                    OpCode(sb, "STC");
                    break;


                case "DAD_SP":
                    OpCode(sb, "DAD", "SP");
                    break;
                case "LDA":
                    OpCodeAddress(sb, stream, "LDA");
                    break;
                case "DCX_SP":
                    OpCode(sb, "DCX", "SP");
                    break;
                case "INR_A":
                    OpCode(sb, "INR", "A");
                    break;
                case "DCR_A":
                    OpCode(sb, "DCR", "A");
                    break;
                case "MVI_A":
                    OpCode8(sb, stream, "MVI", "A");
                    break;
                case "CMC":
                    OpCode(sb, "CMC");
                    break;


                case "MOV_B_B":
                    OpCode(sb, "MOV", "B,B");
                    break;
                case "MOV_B_C":
                    OpCode(sb, "MOV", "B,C");
                    break;
                case "MOV_B_D":
                    OpCode(sb, "MOV", "B,D");
                    break;
                case "MOV_B_E":
                    OpCode(sb, "MOV", "B,E");
                    break;
                case "MOV_B_H":
                    OpCode(sb, "MOV", "B,H");
                    break;
                case "MOV_B_L":
                    OpCode(sb, "MOV", "B,L");
                    break;
                case "MOV_B_M":
                    OpCode(sb, "MOV", "B,M");
                    break;
                case "MOV_B_A":
                    OpCode(sb, "MOV", "B,A");
                    break;

                case "MOV_C_B":
                    OpCode(sb, "MOV", "C,B");
                    break;
                case "MOV_C_C":
                    OpCode(sb, "MOV", "C,C");
                    break;
                case "MOV_C_D":
                    OpCode(sb, "MOV", "C,D");
                    break;
                case "MOV_C_E":
                    OpCode(sb, "MOV", "C,E");
                    break;
                case "MOV_C_H":
                    OpCode(sb, "MOV", "C,H");
                    break;
                case "MOV_C_L":
                    OpCode(sb, "MOV", "C,L");
                    break;
                case "MOV_C_M":
                    OpCode(sb, "MOV", "C,M");
                    break;
                case "MOV_C_A":
                    OpCode(sb, "MOV", "C,A");
                    break;

                case "MOV_D_B":
                    OpCode(sb, "MOV", "D,B");
                    break;
                case "MOV_D_C":
                    OpCode(sb, "MOV", "D,C");
                    break;
                case "MOV_D_D":
                    OpCode(sb, "MOV", "D,D");
                    break;
                case "MOV_D_E":
                    OpCode(sb, "MOV", "D,E");
                    break;
                case "MOV_D_H":
                    OpCode(sb, "MOV", "D,H");
                    break;
                case "MOV_D_L":
                    OpCode(sb, "MOV", "D,L");
                    break;
                case "MOV_D_M":
                    OpCode(sb, "MOV", "D,M");
                    break;
                case "MOV_D_A":
                    OpCode(sb, "MOV", "D,A");
                    break;

                case "MOV_E_B":
                    OpCode(sb, "MOV", "E,B");
                    break;
                case "MOV_E_C":
                    OpCode(sb, "MOV", "E,C");
                    break;
                case "MOV_E_D":
                    OpCode(sb, "MOV", "E,D");
                    break;
                case "MOV_E_E":
                    OpCode(sb, "MOV", "E,E");
                    break;
                case "MOV_E_H":
                    OpCode(sb, "MOV", "E,H");
                    break;
                case "MOV_E_L":
                    OpCode(sb, "MOV", "E,L");
                    break;
                case "MOV_E_M":
                    OpCode(sb, "MOV", "E,M");
                    break;
                case "MOV_E_A":
                    OpCode(sb, "MOV", "E,A");
                    break;

                case "MOV_H_B":
                    OpCode(sb, "MOV", "H,B");
                    break;
                case "MOV_H_C":
                    OpCode(sb, "MOV", "H,C");
                    break;
                case "MOV_H_D":
                    OpCode(sb, "MOV", "H,D");
                    break;
                case "MOV_H_E":
                    OpCode(sb, "MOV", "H,E");
                    break;
                case "MOV_H_H":
                    OpCode(sb, "MOV", "H,H");
                    break;
                case "MOV_H_L":
                    OpCode(sb, "MOV", "H,L");
                    break;
                case "MOV_H_M":
                    OpCode(sb, "MOV", "H,M");
                    break;
                case "MOV_H_A":
                    OpCode(sb, "MOV", "H,A");
                    break;

                case "MOV_L_B":
                    OpCode(sb, "MOV", "L,B");
                    break;
                case "MOV_L_C":
                    OpCode(sb, "MOV", "L,C");
                    break;
                case "MOV_L_D":
                    OpCode(sb, "MOV", "L,D");
                    break;
                case "MOV_L_E":
                    OpCode(sb, "MOV", "L,E");
                    break;
                case "MOV_L_H":
                    OpCode(sb, "MOV", "L,H");
                    break;
                case "MOV_L_L":
                    OpCode(sb, "MOV", "L,L");
                    break;
                case "MOV_L_M":
                    OpCode(sb, "MOV", "L,M");
                    break;
                case "MOV_L_A":
                    OpCode(sb, "MOV", "L,A");
                    break;

                case "MOV_M_B":
                    OpCode(sb, "MOV", "M,B");
                    break;
                case "MOV_M_C":
                    OpCode(sb, "MOV", "M,C");
                    break;
                case "MOV_M_D":
                    OpCode(sb, "MOV", "M,D");
                    break;
                case "MOV_M_E":
                    OpCode(sb, "MOV", "M,E");
                    break;
                case "MOV_M_H":
                    OpCode(sb, "MOV", "M,H");
                    break;
                case "MOV_M_L":
                    OpCode(sb, "MOV", "M,L");
                    break;
                case "HLT":
                    OpCode(sb, "HLT");
                    break;
                case "MOV_M_A":
                    OpCode(sb, "MOV", "M,A");
                    break;

                case "MOV_A_B":
                    OpCode(sb, "MOV", "A,B");
                    break;
                case "MOV_A_C":
                    OpCode(sb, "MOV", "A,C");
                    break;
                case "MOV_A_D":
                    OpCode(sb, "MOV", "A,D");
                    break;
                case "MOV_A_E":
                    OpCode(sb, "MOV", "A,E");
                    break;
                case "MOV_A_H":
                    OpCode(sb, "MOV", "A,H");
                    break;
                case "MOV_A_L":
                    OpCode(sb, "MOV", "A,L");
                    break;
                case "MOV_A_M":
                    OpCode(sb, "MOV", "A,M");
                    break;
                case "MOV_A_A":
                    OpCode(sb, "MOV", "A,A");
                    break;


                case "ADD_B":
                    OpCode(sb, "ADD", "B");
                    break;
                case "ADD_C":
                    OpCode(sb, "ADD", "C");
                    break;
                case "ADD_D":
                    OpCode(sb, "ADD", "D");
                    break;
                case "ADD_E":
                    OpCode(sb, "ADD", "E");
                    break;
                case "ADD_H":
                    OpCode(sb, "ADD", "H");
                    break;
                case "ADD_L":
                    OpCode(sb, "ADD", "L");
                    break;
                case "ADD_M":
                    OpCode(sb, "ADD", "M");
                    break;
                case "ADD_A":
                    OpCode(sb, "ADD", "A");
                    break;

                case "ADC_B":
                    OpCode(sb, "ADC", "B");
                    break;
                case "ADC_C":
                    OpCode(sb, "ADC", "C");
                    break;
                case "ADC_D":
                    OpCode(sb, "ADC", "D");
                    break;
                case "ADC_E":
                    OpCode(sb, "ADC", "E");
                    break;
                case "ADC_H":
                    OpCode(sb, "ADC", "H");
                    break;
                case "ADC_L":
                    OpCode(sb, "ADC", "L");
                    break;
                case "ADC_M":
                    OpCode(sb, "ADC", "M");
                    break;
                case "ADC_A":
                    OpCode(sb, "ADC", "A");
                    break;

                case "SUB_B":
                    OpCode(sb, "SUB", "B");
                    break;
                case "SUB_C":
                    OpCode(sb, "SUB", "C");
                    break;
                case "SUB_D":
                    OpCode(sb, "SUB", "D");
                    break;
                case "SUB_E":
                    OpCode(sb, "SUB", "E");
                    break;
                case "SUB_H":
                    OpCode(sb, "SUB", "H");
                    break;
                case "SUB_L":
                    OpCode(sb, "SUB", "L");
                    break;
                case "SUB_M":
                    OpCode(sb, "SUB", "M");
                    break;
                case "SUB_A":
                    OpCode(sb, "SUB", "A");
                    break;

                case "SBB_B":
                    OpCode(sb, "SBB", "B");
                    break;
                case "SBB_C":
                    OpCode(sb, "SBB", "C");
                    break;
                case "SBB_D":
                    OpCode(sb, "SBB", "D");
                    break;
                case "SBB_E":
                    OpCode(sb, "SBB", "E");
                    break;
                case "SBB_H":
                    OpCode(sb, "SBB", "H");
                    break;
                case "SBB_L":
                    OpCode(sb, "SBB", "L");
                    break;
                case "SBB_M":
                    OpCode(sb, "SBB", "M");
                    break;
                case "SBB_A":
                    OpCode(sb, "SBB", "A");
                    break;

                case "ANA_B":
                    OpCode(sb, "ANA", "B");
                    break;
                case "ANA_C":
                    OpCode(sb, "ANA", "C");
                    break;
                case "ANA_D":
                    OpCode(sb, "ANA", "D");
                    break;
                case "ANA_E":
                    OpCode(sb, "ANA", "E");
                    break;
                case "ANA_H":
                    OpCode(sb, "ANA", "H");
                    break;
                case "ANA_L":
                    OpCode(sb, "ANA", "L");
                    break;
                case "ANA_M":
                    OpCode(sb, "ANA", "M");
                    break;
                case "ANA_A":
                    OpCode(sb, "ANA", "A");
                    break;

                case "XRA_B":
                    OpCode(sb, "XRA", "B");
                    break;
                case "XRA_C":
                    OpCode(sb, "XRA", "C");
                    break;
                case "XRA_D":
                    OpCode(sb, "XRA", "D");
                    break;
                case "XRA_E":
                    OpCode(sb, "XRA", "E");
                    break;
                case "XRA_H":
                    OpCode(sb, "XRA", "H");
                    break;
                case "XRA_L":
                    OpCode(sb, "XRA", "L");
                    break;
                case "XRA_M":
                    OpCode(sb, "XRA", "M");
                    break;
                case "XRA_A":
                    OpCode(sb, "XRA", "A");
                    break;


                case "ORA_B":
                    OpCode(sb, "ORA", "B");
                    break;
                case "ORA_C":
                    OpCode(sb, "ORA", "C");
                    break;
                case "ORA_D":
                    OpCode(sb, "ORA", "D");
                    break;
                case "ORA_E":
                    OpCode(sb, "ORA", "E");
                    break;
                case "ORA_H":
                    OpCode(sb, "ORA", "H");
                    break;
                case "ORA_L":
                    OpCode(sb, "ORA", "L");
                    break;
                case "ORA_M":
                    OpCode(sb, "ORA", "M");
                    break;
                case "ORA_A":
                    OpCode(sb, "ORA", "A");
                    break;


                case "CMP_B":
                    OpCode(sb, "CMP", "B");
                    break;
                case "CMP_C":
                    OpCode(sb, "CMP", "C");
                    break;
                case "CMP_D":
                    OpCode(sb, "CMP", "D");
                    break;
                case "CMP_E":
                    OpCode(sb, "CMP", "E");
                    break;
                case "CMP_H":
                    OpCode(sb, "CMP", "H");
                    break;
                case "CMP_L":
                    OpCode(sb, "CMP", "L");
                    break;
                case "CMP_M":
                    OpCode(sb, "CMP", "M");
                    break;
                case "CMP_A":
                    OpCode(sb, "CMP", "A");
                    break;

                case "RNZ":
                    OpCode(sb, "RNZ");
                    break;
                case "POP_B":
                    OpCode(sb, "POP", "B");
                    break;
                case "JNZ":
                    OpCodeAddress(sb, stream, "JNZ");
                    break;
                case "JMP":
                    OpCodeAddress(sb, stream, "JMP");
                    break;
                case "CNZ":
                    OpCodeAddress(sb, stream, "CNZ");
                    break;
                case "PUSH_B":
                    OpCode(sb, "PUSH", "B");
                    break;
                case "ADI":
                    OpCode8(sb, stream, "ADI");
                    break;
                case "RST_0":
                    OpCode(sb, "RST", "0");
                    break;
                case "RZ":
                    OpCode(sb, "RZ");
                    break;
                case "RET":
                    OpCodeAddress(sb, stream, "RET");
                    break;
                case "JZ":
                    OpCode(sb, "JZ");
                    break;


                case "CZ":
                    OpCodeAddress(sb, stream, "CZ");
                    break;
                case "CALL":
                    OpCodeAddress(sb, stream, "CALL");
                    break;
                case "ACI":
                    OpCode8(sb, stream, "ACI");
                    break;
                case "RST_1":
                    OpCode(sb, "RST", "1");
                    break;

                case "RNC":
                    OpCode(sb, "RNC");
                    break;
                case "POP_D":
                    OpCode(sb, "POP", "D");
                    break;
                case "JNC":
                    OpCodeAddress(sb, stream, "JNC");
                    break;
                case "OUT":
                    OpCode8(sb, stream, "OUT");
                    break;
                case "CNC":
                    OpCodeAddress(sb, stream, "CNC");
                    break;
                case "PUSH_D":
                    OpCode(sb, "PUSH", "D");
                    break;
                case "SUI":
                    OpCode8(sb, stream, "SUI");
                    break;
                case "RST_2":
                    OpCode(sb, "RST", "2");
                    break;
                case "RC":
                    OpCode(sb, "RC");
                    break;


                case "JC":
                    OpCodeAddress(sb, stream, "JC");
                    break;
                case "IN":
                    OpCode8(sb, stream, "IN");
                    break;
                case "CC":
                    OpCodeAddress(sb, stream, "CC");
                    break;


                case "SBI":
                    OpCode8(sb, stream, "SBI");
                    break;
                case "RST_3":
                    OpCode(sb, "RST", "3");
                    break;

                case "RPO":
                    OpCode(sb, "RPO");
                    break;
                case "POP_H":
                    OpCode(sb, "POP", "H");
                    break;
                case "JPO":
                    OpCodeAddress(sb, stream, "JPO");
                    break;
                case "XTHL":
                    OpCode(sb, "XTHL");
                    break;
                case "CPO":
                    OpCodeAddress(sb, stream, "CPO");
                    break;
                case "PUSH_H":
                    OpCode(sb, "PUSH", "H");
                    break;
                case "ANI":
                    OpCode8(sb, stream, "ANI");
                    break;
                case "RST_4":
                    OpCode(sb, "RST", "4");
                    break;
                case "RPE":
                    OpCode(sb, "RPE");
                    break;
                case "PCHL":
                    OpCode(sb, "PCHL");
                    break;
                case "JPE":
                    OpCodeAddress(sb, stream, "JPE");
                    break;
                case "XCHG":
                    OpCode(sb, "XCHG");
                    break;
                case "CPE":
                    OpCodeAddress(sb, stream, "CPE");
                    break;


                case "XRI":
                    OpCode8(sb, stream, "XRI");
                    break;
                case "RST_5":
                    OpCode(sb, "RST", "5");
                    break;

                case "RP":
                    OpCode(sb, "RP");
                    break;
                case "POP_PSW":
                    OpCode(sb, "POP", "PSW");
                    break;
                case "JP":
                    OpCodeAddress(sb, stream, "JP");
                    break;
                case "DI":
                    OpCode(sb, "DI");
                    break;
                case "CP":
                    OpCodeAddress(sb, stream, "CP");
                    break;
                case "PUSH_PSW":
                    OpCode(sb, "PUSH", "PSW");
                    break;
                case "ORI":
                    OpCode8(sb, stream, "ORI");
                    break;
                case "RST_6":
                    OpCode(sb, "RST", "6");
                    break;
                case "RM":
                    OpCode(sb, "RM");
                    break;
                case "SPHL":
                    OpCode(sb, "SPHL");
                    break;
                case "JM":
                    OpCodeAddress(sb, stream, "JM");
                    break;
                case "EI":
                    OpCode(sb, "EI");
                    break;
                case "CM":
                    OpCodeAddress(sb, stream, "CM");
                    break;


                case "CPI":
                    OpCode8(sb, stream, "CPI");
                    break;
                case "RST_7":
                    OpCode(sb, "RST", "7");
                    break;
                */
            }
        }
    }    
}
