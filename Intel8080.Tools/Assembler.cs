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
                case "INX_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.INX_B);
                    }
                    break;
                case "INR_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.INR_B);
                    }
                    break;
                case "DCR_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.DCR_B);
                    }
                    break;
                case "MVI_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.MVI_B);
                    }
                    break;
                case "RLC":
                    stream.WriteByte(OpCodes.RLC);
                    break;


                case "DAD_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.DAD_B);
                    }
                    break;
                case "LDAX_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.INR_B);
                    }
                    break;
                case "DCX_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.DCX_B);
                    }
                    break;
                case "INR_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.INR_C);
                    }
                    break;
                case "DCR_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.DCR_C);
                    }
                    break;
                case "MVI_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.MVI_C);
                    }
                    break;
                case "RRC":
                    stream.WriteByte(OpCodes.RRC);
                    break;


                case "LXI_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.LXI_D);
                    }
                    break;
                case "STAX_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.STAX_D);
                    }
                    break;
                case "INX_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.INX_D);
                    }
                    break;
                case "INR_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.INR_D);
                    }
                    break;
                case "DCR_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.DCR_D);
                    }
                    break;
                case "MVI_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.MVI_D);
                    }
                    break;
                case "RAL":
                    stream.WriteByte(OpCodes.RAL);
                    break;


                case "DAD_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.DAD_D);
                    }
                    break;
                case "LDAX_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.LDAX_D);
                    }
                    break;
                case "DCX_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.DCX_D);
                    }
                    break;
                case "INR_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.INR_E);
                    }
                    break;
                case "DCR_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.DCR_E);
                    }
                    break;
                case "MVI_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.MVI_E);
                    }
                    break;
                case "RAR":
                    stream.WriteByte(OpCodes.RAR);
                    break;


                case "LXI_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.LXI_H);
                    }
                    break;
                case "SHLD":
                    stream.WriteByte(OpCodes.SHLD);
                    break;
                case "INX_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.INX_H);
                    }
                    break;
                case "INR_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.INR_H);
                    }
                    break;
                case "DCR_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.DCR_H);
                    }
                    break;
                case "MVI_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.MVI_H);
                    }
                    break;
                case "DAA":
                    stream.WriteByte(OpCodes.DAA);
                    break;


                case "DAD_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.DAD_H);
                    }
                    break;
                case "LHLD":
                    stream.WriteByte(OpCodes.LHLD);
                    break;
                case "DCX_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.DCX_H);
                    }
                    break;
                case "INR_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.INR_L);
                    }
                    break;
                case "DCR_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.DCR_L);
                    }
                    break;
                case "MVI_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.MVI_L);
                    }
                    break;
                case "CMA":
                    stream.WriteByte(OpCodes.INR_L);
                    break;


                case "LXI_SP":
                    if (operandParts[0] == "SP")
                    {
                        stream.WriteByte(OpCodes.LXI_SP);
                    }
                    break;
                case "STA":
                    stream.WriteByte(OpCodes.STA);
                    break;
                case "INX_SP":
                    if (operandParts[0] == "SP")
                    {
                        stream.WriteByte(OpCodes.INX_SP);
                    }
                    break;
                case "INR_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.INR_M);
                    }
                    break;
                case "DCR_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.DCR_M);
                    }
                    break;
                case "MVI_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.MVI_M);
                    }
                    break;
                case "STC":
                    stream.WriteByte(OpCodes.STC);
                    break;


                case "DAD_SP":
                    if (operandParts[0] == "SP")
                    {
                        stream.WriteByte(OpCodes.DAD_SP);
                    }
                    break;
                case "LDA":
                    stream.WriteByte(OpCodes.LDA);
                    break;
                case "DCX_SP":
                    if (operandParts[0] == "SP")
                    {
                        stream.WriteByte(OpCodes.DCX_SP);
                    }
                    break;
                case "INR_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.INR_A);
                    }
                    break;
                case "DCR_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.DCR_A);
                    }
                    break;
                case "MVI_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.MVI_A);
                    }
                    break;
                case "CMC":
                    stream.WriteByte(OpCodes.CMC);
                    break;


                case "MOV_B_B":
                    if (operandParts[0] == "B,B")
                    {
                        stream.WriteByte(OpCodes.MOV_B_B);
                    }
                    break;
                case "MOV_B_C":
                    if (operandParts[0] == "B,C")
                    {
                        stream.WriteByte(OpCodes.MOV_B_C);
                    }
                    break;
                case "MOV_B_D":
                    if (operandParts[0] == "B,D")
                    {
                        stream.WriteByte(OpCodes.MOV_B_D);
                    }
                    break;
                case "MOV_B_E":
                    if (operandParts[0] == "B,E")
                    {
                        stream.WriteByte(OpCodes.MOV_B_E);
                    }
                    break;
                case "MOV_B_H":
                    if (operandParts[0] == "B,H")
                    {
                        stream.WriteByte(OpCodes.MOV_B_H);
                    }
                    break;
                case "MOV_B_L":
                    if (operandParts[0] == "B,L")
                    {
                        stream.WriteByte(OpCodes.MOV_B_L);
                    }
                    break;
                case "MOV_B_M":
                    if (operandParts[0] == "B,M")
                    {
                        stream.WriteByte(OpCodes.MOV_B_M);
                    }
                    break;
                case "MOV_B_A":
                    if (operandParts[0] == "B,A")
                    {
                        stream.WriteByte(OpCodes.MOV_B_A);
                    }
                    break;

                case "MOV_C_B":
                    if (operandParts[0] == "C,B")
                    {
                        stream.WriteByte(OpCodes.MOV_C_B);
                    }
                    break;
                case "MOV_C_C":
                    if (operandParts[0] == "C,C")
                    {
                        stream.WriteByte(OpCodes.MOV_C_C);
                    }
                    break;
                case "MOV_C_D":
                    if (operandParts[0] == "C,D")
                    {
                        stream.WriteByte(OpCodes.MOV_C_D);
                    }
                    break;
                case "MOV_C_E":
                    if (operandParts[0] == "C,E")
                    {
                        stream.WriteByte(OpCodes.MOV_C_E);
                    }
                    break;
                case "MOV_C_H":
                    if (operandParts[0] == "C,H")
                    {
                        stream.WriteByte(OpCodes.MOV_C_H);
                    }
                    break;
                case "MOV_C_L":
                    if (operandParts[0] == "C,L")
                    {
                        stream.WriteByte(OpCodes.MOV_C_L);
                    }
                    break;
                case "MOV_C_M":
                    if (operandParts[0] == "C,M")
                    {
                        stream.WriteByte(OpCodes.MOV_C_M);
                    }
                    break;
                case "MOV_C_A":
                    if (operandParts[0] == "C,A")
                    {
                        stream.WriteByte(OpCodes.MOV_C_A);
                    }
                    break;

                case "MOV_D_B":
                    if (operandParts[0] == "D,B")
                    {
                        stream.WriteByte(OpCodes.MOV_D_B);
                    }
                    break;
                case "MOV_D_C":
                    if (operandParts[0] == "D,C")
                    {
                        stream.WriteByte(OpCodes.MOV_D_C);
                    }
                    break;
                case "MOV_D_D":
                    if (operandParts[0] == "D,D")
                    {
                        stream.WriteByte(OpCodes.MOV_D_D);
                    }
                    break;
                case "MOV_D_E":
                    if (operandParts[0] == "D,E")
                    {
                        stream.WriteByte(OpCodes.MOV_D_E);
                    }
                    break;
                case "MOV_D_H":
                    if (operandParts[0] == "D,H")
                    {
                        stream.WriteByte(OpCodes.MOV_D_H);
                    }
                    break;
                case "MOV_D_L":
                    if (operandParts[0] == "D,L")
                    {
                        stream.WriteByte(OpCodes.MOV_D_L);
                    }
                    break;
                case "MOV_D_M":
                    if (operandParts[0] == "D,M")
                    {
                        stream.WriteByte(OpCodes.MOV_D_M);
                    }
                    break;
                case "MOV_D_A":
                    if (operandParts[0] == "D,A")
                    {
                        stream.WriteByte(OpCodes.MOV_D_A);
                    }
                    break;

                case "MOV_E_B":
                    if (operandParts[0] == "E,B")
                    {
                        stream.WriteByte(OpCodes.MOV_E_B);
                    }
                    break;
                case "MOV_E_C":
                    if (operandParts[0] == "E,C")
                    {
                        stream.WriteByte(OpCodes.MOV_E_C);
                    }
                    break;
                case "MOV_E_D":
                    if (operandParts[0] == "E,D")
                    {
                        stream.WriteByte(OpCodes.MOV_E_D);
                    }
                    break;
                case "MOV_E_E":
                    if (operandParts[0] == "E,E")
                    {
                        stream.WriteByte(OpCodes.MOV_E_E);
                    }
                    break;
                case "MOV_E_H":
                    if (operandParts[0] == "E,H")
                    {
                        stream.WriteByte(OpCodes.MOV_E_H);
                    }
                    break;
                case "MOV_E_L":
                    if (operandParts[0] == "E,L")
                    {
                        stream.WriteByte(OpCodes.MOV_E_L);
                    }
                    break;
                case "MOV_E_M":
                    if (operandParts[0] == "E,M")
                    {
                        stream.WriteByte(OpCodes.MOV_E_M);
                    }
                    break;
                case "MOV_E_A":
                    if (operandParts[0] == "E,A")
                    {
                        stream.WriteByte(OpCodes.MOV_E_A);
                    }
                    break;

                case "MOV_H_B":
                    if (operandParts[0] == "H,B")
                    {
                        stream.WriteByte(OpCodes.MOV_H_B);
                    }
                    break;
                case "MOV_H_C":
                    if (operandParts[0] == "H,C")
                    {
                        stream.WriteByte(OpCodes.MOV_H_C);
                    }
                    break;
                case "MOV_H_D":
                    if (operandParts[0] == "H,D")
                    {
                        stream.WriteByte(OpCodes.MOV_H_D);
                    }
                    break;
                case "MOV_H_E":
                    if (operandParts[0] == "H,E")
                    {
                        stream.WriteByte(OpCodes.MOV_H_E);
                    }
                    break;
                case "MOV_H_H":
                    if (operandParts[0] == "H,H")
                    {
                        stream.WriteByte(OpCodes.MOV_H_H);
                    }
                    break;
                case "MOV_H_L":
                    if (operandParts[0] == "H,L")
                    {
                        stream.WriteByte(OpCodes.MOV_H_L);
                    }
                    break;
                case "MOV_H_M":
                    if (operandParts[0] == "H,M")
                    {
                        stream.WriteByte(OpCodes.MOV_H_M);
                    }
                    break;
                case "MOV_H_A":
                    if (operandParts[0] == "H,A")
                    {
                        stream.WriteByte(OpCodes.MOV_H_A);
                    }
                    break;

                case "MOV_L_B":
                    if (operandParts[0] == "L,B")
                    {
                        stream.WriteByte(OpCodes.MOV_L_B);
                    }
                    break;
                case "MOV_L_C":
                    if (operandParts[0] == "L,C")
                    {
                        stream.WriteByte(OpCodes.MOV_L_C);
                    }
                    break;
                case "MOV_L_D":
                    if (operandParts[0] == "L,D")
                    {
                        stream.WriteByte(OpCodes.MOV_L_D);
                    }
                    break;
                case "MOV_L_E":
                    if (operandParts[0] == "L,E")
                    {
                        stream.WriteByte(OpCodes.MOV_L_E);
                    }
                    break;
                case "MOV_L_H":
                    if (operandParts[0] == "L,H")
                    {
                        stream.WriteByte(OpCodes.MOV_L_H);
                    }
                    break;
                case "MOV_L_L":
                    if (operandParts[0] == "L,L")
                    {
                        stream.WriteByte(OpCodes.MOV_L_L);
                    }
                    break;
                case "MOV_L_M":
                    if (operandParts[0] == "L,M")
                    {
                        stream.WriteByte(OpCodes.MOV_L_M);
                    }
                    break;
                case "MOV_L_A":
                    if (operandParts[0] == "L,A")
                    {
                        stream.WriteByte(OpCodes.MOV_L_A);
                    }
                    break;

                case "MOV_M_B":
                    if (operandParts[0] == "M,B")
                    {
                        stream.WriteByte(OpCodes.MOV_M_B);
                    }
                    break;
                case "MOV_M_C":
                    if (operandParts[0] == "M,C")
                    {
                        stream.WriteByte(OpCodes.MOV_M_C);
                    }
                    break;
                case "MOV_M_D":
                    if (operandParts[0] == "M,D")
                    {
                        stream.WriteByte(OpCodes.MOV_M_D);
                    }
                    break;
                case "MOV_M_E":
                    if (operandParts[0] == "M,E")
                    {
                        stream.WriteByte(OpCodes.MOV_M_E);
                    }
                    break;
                case "MOV_M_H":
                    if (operandParts[0] == "M,H")
                    {
                        stream.WriteByte(OpCodes.MOV_M_H);
                    }
                    break;
                case "MOV_M_L":
                    if (operandParts[0] == "M,B")
                    {
                        stream.WriteByte(OpCodes.MOV_M_B);
                    }
                    break;
                case "HLT":
                    stream.WriteByte(OpCodes.HLT);
                    break;
                case "MOV_M_A":
                    if (operandParts[0] == "M,A")
                    {
                        stream.WriteByte(OpCodes.MOV_M_A);
                    }
                    break;

                case "MOV_A_B":
                    if (operandParts[0] == "A,B")
                    {
                        stream.WriteByte(OpCodes.MOV_A_B);
                    }
                    break;
                case "MOV_A_C":
                    if (operandParts[0] == "A,C")
                    {
                        stream.WriteByte(OpCodes.MOV_A_C);
                    }
                    break;
                case "MOV_A_D":
                    if (operandParts[0] == "A,D")
                    {
                        stream.WriteByte(OpCodes.MOV_A_D);
                    }
                    break;
                case "MOV_A_E":
                    if (operandParts[0] == "A,E")
                    {
                        stream.WriteByte(OpCodes.MOV_A_E);
                    }
                    break;
                case "MOV_A_H":
                    if (operandParts[0] == "A,H")
                    {
                        stream.WriteByte(OpCodes.MOV_A_H);
                    }
                    break;
                case "MOV_A_L":
                    if (operandParts[0] == "A,L")
                    {
                        stream.WriteByte(OpCodes.MOV_A_L);
                    }
                    break;
                case "MOV_A_M":
                    if (operandParts[0] == "A,M")
                    {
                        stream.WriteByte(OpCodes.MOV_A_M);
                    }
                    break;
                case "MOV_A_A":
                    if (operandParts[0] == "A,A")
                    {
                        stream.WriteByte(OpCodes.MOV_A_A);
                    }
                    break;


                case "ADD_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.ADD_B);
                    }
                    break;
                case "ADD_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.ADD_C);
                    }
                    break;
                case "ADD_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.ADD_D);
                    }
                    break;
                case "ADD_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.ADD_E);
                    }
                    break;
                case "ADD_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.ADD_H);
                    }
                    break;
                case "ADD_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.ADD_L);
                    }
                    break;
                case "ADD_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.ADD_M);
                    }
                    break;
                case "ADD_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.ADD_A);
                    }
                    break;

                case "ADC_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.ADC_B);
                    }
                    break;
                case "ADC_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.ADC_C);
                    }
                    break;
                case "ADC_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.ADC_D);
                    }
                    break;
                case "ADC_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.ADC_E);
                    }
                    break;
                case "ADC_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.ADC_H);
                    }
                    break;
                case "ADC_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.ADC_L);
                    }
                    break;
                case "ADC_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.ADC_M);
                    }
                    break;
                case "ADC_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.ADC_A);
                    }
                    break;

                case "SUB_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.SUB_B);
                    }
                    break;
                case "SUB_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.SUB_C);
                    }
                    break;
                case "SUB_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.SUB_D);
                    }
                    break;
                case "SUB_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.SUB_E);
                    }
                    break;
                case "SUB_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.SUB_H);
                    }
                    break;
                case "SUB_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.SUB_L);
                    }
                    break;
                case "SUB_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.SUB_M);
                    }
                    break;
                case "SUB_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.SUB_A);
                    }
                    break;

                case "SBB_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.SBB_B);
                    }
                    break;
                case "SBB_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.SBB_C);
                    }
                    break;
                case "SBB_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.SBB_D);
                    }
                    break;
                case "SBB_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.SBB_E);
                    }
                    break;
                case "SBB_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.SBB_H);
                    }
                    break;
                case "SBB_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.SBB_L);
                    }
                    break;
                case "SBB_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.SBB_M);
                    }
                    break;
                case "SBB_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.SBB_A);
                    }
                    break;

                case "ANA_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.ANA_B);
                    }
                    break;
                case "ANA_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.ANA_C);
                    }
                    break;
                case "ANA_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.ANA_D);
                    }
                    break;
                case "ANA_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.ANA_E);
                    }
                    break;
                case "ANA_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.ANA_H);
                    }
                    break;
                case "ANA_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.ANA_L);
                    }
                    break;
                case "ANA_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.ANA_M);
                    }
                    break;
                case "ANA_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.ANA_A);
                    }
                    break;

                case "XRA_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.XRA_B);
                    }
                    break;
                case "XRA_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.XRA_C);
                    }
                    break;
                case "XRA_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.XRA_D);
                    }
                    break;
                case "XRA_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.XRA_E);
                    }
                    break;
                case "XRA_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.XRA_H);
                    }
                    break;
                case "XRA_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.XRA_L);
                    }
                    break;
                case "XRA_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.XRA_M);
                    }
                    break;
                case "XRA_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.XRA_A);
                    }
                    break;


                case "ORA_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.ORA_B);
                    }
                    break;
                case "ORA_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.ORA_C);
                    }
                    break;
                case "ORA_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.ORA_D);
                    }
                    break;
                case "ORA_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.ORA_E);
                    }
                    break;
                case "ORA_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.ORA_H);
                    }
                    break;
                case "ORA_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.ORA_L);
                    }
                    break;
                case "ORA_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.ORA_M);
                    }
                    break;
                case "ORA_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.ORA_A);
                    }
                    break;


                case "CMP_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.CMP_B);
                    }
                    break;
                case "CMP_C":
                    if (operandParts[0] == "C")
                    {
                        stream.WriteByte(OpCodes.CMP_C);
                    }
                    break;
                case "CMP_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.CMP_D);
                    }
                    break;
                case "CMP_E":
                    if (operandParts[0] == "E")
                    {
                        stream.WriteByte(OpCodes.CMP_E);
                    }
                    break;
                case "CMP_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.CMP_H);
                    }
                    break;
                case "CMP_L":
                    if (operandParts[0] == "L")
                    {
                        stream.WriteByte(OpCodes.CMP_L);
                    }
                    break;
                case "CMP_M":
                    if (operandParts[0] == "M")
                    {
                        stream.WriteByte(OpCodes.CMP_M);
                    }
                    break;
                case "CMP_A":
                    if (operandParts[0] == "A")
                    {
                        stream.WriteByte(OpCodes.CMP_A);
                    }
                    break;

                case "RNZ":
                    stream.WriteByte(OpCodes.RNZ);
                    break;
                case "POP_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.POP_B);
                    }
                    break;
                case "JNZ":
                    stream.WriteByte(OpCodes.JNZ);
                    break;
                case "JMP":
                    stream.WriteByte(OpCodes.JMP);
                    break;
                case "CNZ":
                    stream.WriteByte(OpCodes.CNZ);
                    break;
                case "PUSH_B":
                    if (operandParts[0] == "B")
                    {
                        stream.WriteByte(OpCodes.PUSH_B);
                    }
                    break;
                case "ADI":
                    stream.WriteByte(OpCodes.ADI);
                    break;
                case "RST_0":
                    if (operandParts[0] == "0")
                    {
                        stream.WriteByte(OpCodes.RST_0);
                    }
                    break;
                case "RZ":
                    stream.WriteByte(OpCodes.RZ);
                    break;
                case "RET":
                    stream.WriteByte(OpCodes.RET);
                    break;
                case "JZ":
                    stream.WriteByte(OpCodes.JZ);
                    break;


                case "CZ":
                    stream.WriteByte(OpCodes.CZ);
                    break;
                case "CALL":
                    stream.WriteByte(OpCodes.CALL);
                    break;
                case "ACI":
                    stream.WriteByte(OpCodes.ACI);
                    break;
                case "RST_1":
                    if (operandParts[0] == "1")
                    {
                        stream.WriteByte(OpCodes.RST_1);
                    }
                    break;

                case "RNC":
                    stream.WriteByte(OpCodes.RNC);
                    break;
                case "POP_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.POP_D);
                    }
                    break;
                case "JNC":
                    stream.WriteByte(OpCodes.JNC);
                    break;
                case "OUT":
                    stream.WriteByte(OpCodes.OUT);
                    break;
                case "CNC":
                    stream.WriteByte(OpCodes.CNC);
                    break;
                case "PUSH_D":
                    if (operandParts[0] == "D")
                    {
                        stream.WriteByte(OpCodes.PUSH_D);
                    }
                    break;
                case "SUI":
                    stream.WriteByte(OpCodes.SUI);
                    break;
                case "RST_2":
                    if (operandParts[0] == "2")
                    {
                        stream.WriteByte(OpCodes.RST_2);
                    }
                    break;
                case "RC":
                    stream.WriteByte(OpCodes.RC);
                    break;


                case "JC":
                    stream.WriteByte(OpCodes.JC);
                    break;
                case "IN":
                    stream.WriteByte(OpCodes.IN);
                    break;
                case "CC":
                    stream.WriteByte(OpCodes.CC);
                    break;


                case "SBI":
                    stream.WriteByte(OpCodes.SBI);
                    break;
                case "RST_3":
                    if (operandParts[0] == "3")
                    {
                        stream.WriteByte(OpCodes.RST_3);
                    }
                    break;

                case "RPO":
                    stream.WriteByte(OpCodes.RPO);
                    break;
                case "POP_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.POP_H);
                    }
                    break;
                case "JPO":
                    stream.WriteByte(OpCodes.JPO);
                    break;
                case "XTHL":
                    stream.WriteByte(OpCodes.XTHL);
                    break;
                case "CPO":
                    stream.WriteByte(OpCodes.CPO);
                    break;
                case "PUSH_H":
                    if (operandParts[0] == "H")
                    {
                        stream.WriteByte(OpCodes.PUSH_H);
                    }
                    break;
                case "ANI":
                    stream.WriteByte(OpCodes.ANI);
                    break;
                case "RST_4":
                    if (operandParts[0] == "4")
                    {
                        stream.WriteByte(OpCodes.RST_4);
                    }
                    break;
                case "RPE":
                    stream.WriteByte(OpCodes.RPE);
                    break;
                case "PCHL":
                    stream.WriteByte(OpCodes.PCHL);
                    break;
                case "JPE":
                    stream.WriteByte(OpCodes.JPE);
                    break;
                case "XCHG":
                    stream.WriteByte(OpCodes.XCHG);
                    break;
                case "CPE":
                    stream.WriteByte(OpCodes.CPE);
                    break;


                case "XRI":
                    stream.WriteByte(OpCodes.XRI);
                    break;
                case "RST_5":
                    if (operandParts[0] == "5")
                    {
                        stream.WriteByte(OpCodes.RST_5);
                    }
                    break;

                case "RP":
                    stream.WriteByte(OpCodes.RP);
                    break;
                case "POP_PSW":
                    if (operandParts[0] == "PSW")
                    {
                        stream.WriteByte(OpCodes.POP_PSW);
                    }
                    break;
                case "JP":
                    stream.WriteByte(OpCodes.JP);
                    break;
                case "DI":
                    stream.WriteByte(OpCodes.DI);
                    break;
                case "CP":
                    stream.WriteByte(OpCodes.CP);
                    break;
                case "PUSH_PSW":
                    if (operandParts[0] == "PSW")
                    {
                        stream.WriteByte(OpCodes.PUSH_PSW);
                    }
                    break;
                case "ORI":
                    stream.WriteByte(OpCodes.ORI);
                    break;
                case "RST_6":
                    if (operandParts[0] == "6")
                    {
                        stream.WriteByte(OpCodes.RST_6);
                    }
                    break;
                case "RM":
                    stream.WriteByte(OpCodes.RM);
                    break;
                case "SPHL":
                    stream.WriteByte(OpCodes.SPHL);
                    break;
                case "JM":
                    stream.WriteByte(OpCodes.JM);
                    break;
                case "EI":
                    stream.WriteByte(OpCodes.EI);
                    break;
                case "CM":
                    stream.WriteByte(OpCodes.CM);
                    break;


                case "CPI":
                    stream.WriteByte(OpCodes.CPI);
                    break;
                case "RST_7":
                    if (operandParts[0] == "7")
                    {
                        stream.WriteByte(OpCodes.RST_7);
                    }
                    break;
            }
        }
    }    
}
