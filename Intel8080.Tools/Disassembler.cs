using System;
using System.IO;
using System.Text;

namespace Intel8080.Tools
{
    public class Disassembler
    {

        public static string Execute(Stream stream)
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                int opCode = stream.ReadByte();

                if (opCode == -1)
                    break;

                switch ((byte)opCode)
                {
                    case OpCodes.NOP:
                        OpCode(sb, "NOP");
                        break;
                    case OpCodes.LXI_B:
                        OpCode16(sb, stream, "LXI", "B");
                        break;
                    case OpCodes.STAX_B:
                        OpCode(sb, "STAX", "B");
                        break;
                    case OpCodes.INX_B:
                        OpCode(sb, "INX", "B");
                        break;
                    case OpCodes.INR_B:
                        OpCode(sb, "INR", "B");
                        break;
                    case OpCodes.DCR_B:
                        OpCode(sb, "DCR", "B");
                        break;
                    case OpCodes.MVI_B:
                        OpCode8(sb, stream, "MVI", "B");
                        break;
                    case OpCodes.RLC:
                        OpCode(sb, "RLC");
                        break;


                    case OpCodes.DAD_B:
                        OpCode(sb, "DAD", "B");
                        break;
                    case OpCodes.LDAX_B:
                        OpCode(sb, "LDAX", "B");
                        break;
                    case OpCodes.DCX_B:
                        OpCode(sb, "DCX", "B");
                        break;
                    case OpCodes.INR_C:
                        OpCode(sb, "INR", "C");
                        break;
                    case OpCodes.DCR_C:
                        OpCode(sb, "DCR", "C");
                        break;
                    case OpCodes.MVI_C:
                        OpCode8(sb, stream, "MVI", "C");
                        break;
                    case OpCodes.RRC:
                        OpCode(sb, "RRC");
                        break;


                    case OpCodes.LXI_D:
                        OpCode16(sb, stream, "LXI", "D");
                        break;
                    case OpCodes.STAX_D:
                        OpCode(sb, "STAX", "D");
                        break;
                    case OpCodes.INX_D:
                        OpCode(sb, "INX", "D");
                        break;
                    case OpCodes.INR_D:
                        OpCode(sb, "INR", "D");
                        break;
                    case OpCodes.DCR_D:
                        OpCode(sb, "DCR", "D");
                        break;
                    case OpCodes.MVI_D:
                        OpCode8(sb, stream, "MVI", "D");
                        break;
                    case OpCodes.RAL:
                        OpCode(sb, "RAL");
                        break;


                    case OpCodes.DAD_D:
                        OpCode(sb, "DAD", "D");
                        break;
                    case OpCodes.LDAX_D:
                        OpCode(sb, "LDAX", "D");
                        break;
                    case OpCodes.DCX_D:
                        OpCode(sb, "DCX", "D");
                        break;
                    case OpCodes.INR_E:
                        OpCode(sb, "INR", "E");
                        break;
                    case OpCodes.DCR_E:
                        OpCode(sb, "DCR", "E");
                        break;
                    case OpCodes.MVI_E:
                        OpCode8(sb, stream, "MVI", "E");
                        break;
                    case OpCodes.RAR:
                        OpCode(sb, "RAR");
                        break;


                    case OpCodes.LXI_H:
                        OpCode16(sb, stream, "LXI", "H");
                        break;
                    case OpCodes.SHLD:
                        OpCodeAddress(sb, stream, "SHLD");
                        break;
                    case OpCodes.INX_H:
                        OpCode(sb, "INX", "H");
                        break;
                    case OpCodes.INR_H:
                        OpCode(sb, "INR", "H");
                        break;
                    case OpCodes.DCR_H:
                        OpCode(sb, "DCR", "H");
                        break;
                    case OpCodes.MVI_H:
                        OpCode8(sb, stream, "MVI", "H");
                        break;
                    case OpCodes.DAA:
                        OpCode(sb, "DAA");
                        break;


                    case OpCodes.DAD_H:
                        OpCode(sb, "DAD", "H");
                        break;
                    case OpCodes.LHLD:
                        OpCodeAddress(sb, stream, "LHLD");
                        break;
                    case OpCodes.DCX_H:
                        OpCode(sb, "DCX", "H");
                        break;
                    case OpCodes.INR_L:
                        OpCode(sb, "INR", "L");
                        break;
                    case OpCodes.DCR_L:
                        OpCode(sb, "DCR", "L");
                        break;
                    case OpCodes.MVI_L:
                        OpCode8(sb, stream, "MVI", "L");
                        break;
                    case OpCodes.CMA:
                        OpCode(sb, "CMA");
                        break;


                    case OpCodes.LXI_SP:
                        OpCode16(sb, stream, "LXI", "SP");
                        break;
                    case OpCodes.STA:
                        OpCodeAddress(sb, stream, "STA");
                        break;
                    case OpCodes.INX_SP:
                        OpCode(sb, "INX", "SP");
                        break;
                    case OpCodes.INR_M:
                        OpCode(sb, "INR", "M");
                        break;
                    case OpCodes.DCR_M:
                        OpCode(sb, "DCR", "M");
                        break;
                    case OpCodes.MVI_M:
                        OpCode8(sb, stream, "MVI", "M");
                        break;
                    case OpCodes.STC:
                        OpCode(sb, "STC");
                        break;


                    case OpCodes.DAD_SP:
                        OpCode(sb, "DAD", "SP");
                        break;
                    case OpCodes.LDA:
                        OpCodeAddress(sb, stream, "LDA");
                        break;
                    case OpCodes.DCX_SP:
                        OpCode(sb, "DCX", "SP");
                        break;
                    case OpCodes.INR_A:
                        OpCode(sb, "INR", "A");
                        break;
                    case OpCodes.DCR_A:
                        OpCode(sb, "DCR", "A");
                        break;
                    case OpCodes.MVI_A:
                        OpCode8(sb, stream, "MVI", "A");
                        break;
                    case OpCodes.CMC:
                        OpCode(sb, "CMC");
                        break;


                    case OpCodes.MOV_B_B:
                        OpCode(sb, "MOV", "B,B");
                        break;
                    case OpCodes.MOV_B_C:
                        OpCode(sb, "MOV", "B,C");
                        break;
                    case OpCodes.MOV_B_D:
                        OpCode(sb, "MOV", "B,D");
                        break;
                    case OpCodes.MOV_B_E:
                        OpCode(sb, "MOV", "B,E");
                        break;
                    case OpCodes.MOV_B_H:
                        OpCode(sb, "MOV", "B,H");
                        break;
                    case OpCodes.MOV_B_L:
                        OpCode(sb, "MOV", "B,L");
                        break;
                    case OpCodes.MOV_B_M:
                        OpCode(sb, "MOV", "B,M");
                        break;
                    case OpCodes.MOV_B_A:
                        OpCode(sb, "MOV", "B,A");
                        break;

                    case OpCodes.MOV_C_B:
                        OpCode(sb, "MOV", "C,B");
                        break;
                    case OpCodes.MOV_C_C:
                        OpCode(sb, "MOV", "C,C");
                        break;
                    case OpCodes.MOV_C_D:
                        OpCode(sb, "MOV", "C,D");
                        break;
                    case OpCodes.MOV_C_E:
                        OpCode(sb, "MOV", "C,E");
                        break;
                    case OpCodes.MOV_C_H:
                        OpCode(sb, "MOV", "C,H");
                        break;
                    case OpCodes.MOV_C_L:
                        OpCode(sb, "MOV", "C,L");
                        break;
                    case OpCodes.MOV_C_M:
                        OpCode(sb, "MOV", "C,M");
                        break;
                    case OpCodes.MOV_C_A:
                        OpCode(sb, "MOV", "C,A");
                        break;

                    case OpCodes.MOV_D_B:
                        OpCode(sb, "MOV", "D,B");
                        break;
                    case OpCodes.MOV_D_C:
                        OpCode(sb, "MOV", "D,C");
                        break;
                    case OpCodes.MOV_D_D:
                        OpCode(sb, "MOV", "D,D");
                        break;
                    case OpCodes.MOV_D_E:
                        OpCode(sb, "MOV", "D,E");
                        break;
                    case OpCodes.MOV_D_H:
                        OpCode(sb, "MOV", "D,H");
                        break;
                    case OpCodes.MOV_D_L:
                        OpCode(sb, "MOV", "D,L");
                        break;
                    case OpCodes.MOV_D_M:
                        OpCode(sb, "MOV", "D,M");
                        break;
                    case OpCodes.MOV_D_A:
                        OpCode(sb, "MOV", "D,A");
                        break;

                    case OpCodes.MOV_E_B:
                        OpCode(sb, "MOV", "E,B");
                        break;
                    case OpCodes.MOV_E_C:
                        OpCode(sb, "MOV", "E,C");
                        break;
                    case OpCodes.MOV_E_D:
                        OpCode(sb, "MOV", "E,D");
                        break;
                    case OpCodes.MOV_E_E:
                        OpCode(sb, "MOV", "E,E");
                        break;
                    case OpCodes.MOV_E_H:
                        OpCode(sb, "MOV", "E,H");
                        break;
                    case OpCodes.MOV_E_L:
                        OpCode(sb, "MOV", "E,L");
                        break;
                    case OpCodes.MOV_E_M:
                        OpCode(sb, "MOV", "E,M");
                        break;
                    case OpCodes.MOV_E_A:
                        OpCode(sb, "MOV", "E,A");
                        break;

                    case OpCodes.MOV_H_B:
                        OpCode(sb, "MOV", "H,B");
                        break;
                    case OpCodes.MOV_H_C:
                        OpCode(sb, "MOV", "H,C");
                        break;
                    case OpCodes.MOV_H_D:
                        OpCode(sb, "MOV", "H,D");
                        break;
                    case OpCodes.MOV_H_E:
                        OpCode(sb, "MOV", "H,E");
                        break;
                    case OpCodes.MOV_H_H:
                        OpCode(sb, "MOV", "H,H");
                        break;
                    case OpCodes.MOV_H_L:
                        OpCode(sb, "MOV", "H,L");
                        break;
                    case OpCodes.MOV_H_M:
                        OpCode(sb, "MOV", "H,M");
                        break;
                    case OpCodes.MOV_H_A:
                        OpCode(sb, "MOV", "H,A");
                        break;

                    case OpCodes.MOV_L_B:
                        OpCode(sb, "MOV", "L,B");
                        break;
                    case OpCodes.MOV_L_C:
                        OpCode(sb, "MOV", "L,C");
                        break;
                    case OpCodes.MOV_L_D:
                        OpCode(sb, "MOV", "L,D");
                        break;
                    case OpCodes.MOV_L_E:
                        OpCode(sb, "MOV", "L,E");
                        break;
                    case OpCodes.MOV_L_H:
                        OpCode(sb, "MOV", "L,H");
                        break;
                    case OpCodes.MOV_L_L:
                        OpCode(sb, "MOV", "L,L");
                        break;
                    case OpCodes.MOV_L_M:
                        OpCode(sb, "MOV", "L,M");
                        break;
                    case OpCodes.MOV_L_A:
                        OpCode(sb, "MOV", "L,A");
                        break;

                    case OpCodes.MOV_M_B:
                        OpCode(sb, "MOV", "M,B");
                        break;
                    case OpCodes.MOV_M_C:
                        OpCode(sb, "MOV", "M,C");
                        break;
                    case OpCodes.MOV_M_D:
                        OpCode(sb, "MOV", "M,D");
                        break;
                    case OpCodes.MOV_M_E:
                        OpCode(sb, "MOV", "M,E");
                        break;
                    case OpCodes.MOV_M_H:
                        OpCode(sb, "MOV", "M,H");
                        break;
                    case OpCodes.MOV_M_L:
                        OpCode(sb, "MOV", "M,L");
                        break;
                    case OpCodes.HLT:
                        OpCode(sb, "HLT");
                        break;
                    case OpCodes.MOV_M_A:
                        OpCode(sb, "MOV", "M,A");
                        break;

                    case OpCodes.MOV_A_B:
                        OpCode(sb, "MOV", "A,B");
                        break;
                    case OpCodes.MOV_A_C:
                        OpCode(sb, "MOV", "A,C");
                        break;
                    case OpCodes.MOV_A_D:
                        OpCode(sb, "MOV", "A,D");
                        break;
                    case OpCodes.MOV_A_E:
                        OpCode(sb, "MOV", "A,E");
                        break;
                    case OpCodes.MOV_A_H:
                        OpCode(sb, "MOV", "A,H");
                        break;
                    case OpCodes.MOV_A_L:
                        OpCode(sb, "MOV", "A,L");
                        break;
                    case OpCodes.MOV_A_M:
                        OpCode(sb, "MOV", "A,M");
                        break;
                    case OpCodes.MOV_A_A:
                        OpCode(sb, "MOV", "A,A");
                        break;


                    case OpCodes.ADD_B:
                        OpCode(sb, "ADD", "B");
                        break;
                    case OpCodes.ADD_C:
                        OpCode(sb, "ADD", "C");
                        break;
                    case OpCodes.ADD_D:
                        OpCode(sb, "ADD", "D");
                        break;
                    case OpCodes.ADD_E:
                        OpCode(sb, "ADD", "E");
                        break;
                    case OpCodes.ADD_H:
                        OpCode(sb, "ADD", "H");
                        break;
                    case OpCodes.ADD_L:
                        OpCode(sb, "ADD", "L");
                        break;
                    case OpCodes.ADD_M:
                        OpCode(sb, "ADD", "M");
                        break;
                    case OpCodes.ADD_A:
                        OpCode(sb, "ADD", "A");
                        break;

                    case OpCodes.ADC_B:
                        OpCode(sb, "ADC", "B");
                        break;
                    case OpCodes.ADC_C:
                        OpCode(sb, "ADC", "C");
                        break;
                    case OpCodes.ADC_D:
                        OpCode(sb, "ADC", "D");
                        break;
                    case OpCodes.ADC_E:
                        OpCode(sb, "ADC", "E");
                        break;
                    case OpCodes.ADC_H:
                        OpCode(sb, "ADC", "H");
                        break;
                    case OpCodes.ADC_L:
                        OpCode(sb, "ADC", "L");
                        break;
                    case OpCodes.ADC_M:
                        OpCode(sb, "ADC", "M");
                        break;
                    case OpCodes.ADC_A:
                        OpCode(sb, "ADC", "A");
                        break;

                    case OpCodes.SUB_B:
                        OpCode(sb, "SUB", "B");
                        break;
                    case OpCodes.SUB_C:
                        OpCode(sb, "SUB", "C");
                        break;
                    case OpCodes.SUB_D:
                        OpCode(sb, "SUB", "D");
                        break;
                    case OpCodes.SUB_E:
                        OpCode(sb, "SUB", "E");
                        break;
                    case OpCodes.SUB_H:
                        OpCode(sb, "SUB", "H");
                        break;
                    case OpCodes.SUB_L:
                        OpCode(sb, "SUB", "L");
                        break;
                    case OpCodes.SUB_M:
                        OpCode(sb, "SUB", "M");
                        break;
                    case OpCodes.SUB_A:
                        OpCode(sb, "SUB", "A");
                        break;

                    case OpCodes.SBB_B:
                        OpCode(sb, "SBB", "B");
                        break;
                    case OpCodes.SBB_C:
                        OpCode(sb, "SBB", "C");
                        break;
                    case OpCodes.SBB_D:
                        OpCode(sb, "SBB", "D");
                        break;
                    case OpCodes.SBB_E:
                        OpCode(sb, "SBB", "E");
                        break;
                    case OpCodes.SBB_H:
                        OpCode(sb, "SBB", "H");
                        break;
                    case OpCodes.SBB_L:
                        OpCode(sb, "SBB", "L");
                        break;
                    case OpCodes.SBB_M:
                        OpCode(sb, "SBB", "M");
                        break;
                    case OpCodes.SBB_A:
                        OpCode(sb, "SBB", "A");
                        break;

                    case OpCodes.ANA_B:
                        OpCode(sb, "ANA", "B");
                        break;
                    case OpCodes.ANA_C:
                        OpCode(sb, "ANA", "C");
                        break;
                    case OpCodes.ANA_D:
                        OpCode(sb, "ANA", "D");
                        break;
                    case OpCodes.ANA_E:
                        OpCode(sb, "ANA", "E");
                        break;
                    case OpCodes.ANA_H:
                        OpCode(sb, "ANA", "H");
                        break;
                    case OpCodes.ANA_L:
                        OpCode(sb, "ANA", "L");
                        break;
                    case OpCodes.ANA_M:
                        OpCode(sb, "ANA", "M");
                        break;
                    case OpCodes.ANA_A:
                        OpCode(sb, "ANA", "A");
                        break;

                    case OpCodes.XRA_B:
                        OpCode(sb, "XRA", "B");
                        break;
                    case OpCodes.XRA_C:
                        OpCode(sb, "XRA", "C");
                        break;
                    case OpCodes.XRA_D:
                        OpCode(sb, "XRA", "D");
                        break;
                    case OpCodes.XRA_E:
                        OpCode(sb, "XRA", "E");
                        break;
                    case OpCodes.XRA_H:
                        OpCode(sb, "XRA", "H");
                        break;
                    case OpCodes.XRA_L:
                        OpCode(sb, "XRA", "L");
                        break;
                    case OpCodes.XRA_M:
                        OpCode(sb, "XRA", "M");
                        break;
                    case OpCodes.XRA_A:
                        OpCode(sb, "XRA", "A");
                        break;


                    case OpCodes.ORA_B:
                        OpCode(sb, "ORA", "B");
                        break;
                    case OpCodes.ORA_C:
                        OpCode(sb, "ORA", "C");
                        break;
                    case OpCodes.ORA_D:
                        OpCode(sb, "ORA", "D");
                        break;
                    case OpCodes.ORA_E:
                        OpCode(sb, "ORA", "E");
                        break;
                    case OpCodes.ORA_H:
                        OpCode(sb, "ORA", "H");
                        break;
                    case OpCodes.ORA_L:
                        OpCode(sb, "ORA", "L");
                        break;
                    case OpCodes.ORA_M:
                        OpCode(sb, "ORA", "M");
                        break;
                    case OpCodes.ORA_A:
                        OpCode(sb, "ORA", "A");
                        break;


                    case OpCodes.CMP_B:
                        OpCode(sb, "CMP", "B");
                        break;
                    case OpCodes.CMP_C:
                        OpCode(sb, "CMP", "C");
                        break;
                    case OpCodes.CMP_D:
                        OpCode(sb, "CMP", "D");
                        break;
                    case OpCodes.CMP_E:
                        OpCode(sb, "CMP", "E");
                        break;
                    case OpCodes.CMP_H:
                        OpCode(sb, "CMP", "H");
                        break;
                    case OpCodes.CMP_L:
                        OpCode(sb, "CMP", "L");
                        break;
                    case OpCodes.CMP_M:
                        OpCode(sb, "CMP", "M");
                        break;
                    case OpCodes.CMP_A:
                        OpCode(sb, "CMP", "A");
                        break;

                    case OpCodes.RNZ:
                        OpCode(sb, "RNZ");
                        break;
                    case OpCodes.POP_B:
                        OpCode(sb, "POP", "B");
                        break;
                    case OpCodes.JNZ:
                        OpCodeAddress(sb, stream, "JNZ");
                        break;
                    case OpCodes.JMP:
                        OpCodeAddress(sb, stream, "JMP");
                        break;
                    case OpCodes.CNZ:
                        OpCodeAddress(sb, stream, "CNZ");
                        break;
                    case OpCodes.PUSH_B:
                        OpCode(sb, "PUSH", "B");
                        break;
                    case OpCodes.ADI:
                        OpCode8(sb, stream, "ADI");
                        break;
                    case OpCodes.RST_0:
                        OpCode(sb, "RST", "0");
                        break;
                    case OpCodes.RZ:
                        OpCode(sb, "RZ");
                        break;
                    case OpCodes.RET:
                        OpCodeAddress(sb, stream, "RET");
                        break;
                    case OpCodes.JZ:
                        OpCode(sb, "JZ");
                        break;


                    case OpCodes.CZ:
                        OpCodeAddress(sb, stream, "CZ");
                        break;
                    case OpCodes.CALL:
                        OpCodeAddress(sb, stream, "CALL");
                        break;
                    case OpCodes.ACI:
                        OpCode8(sb, stream, "ACI");
                        break;
                    case OpCodes.RST_1:
                        OpCode(sb, "RST", "1");
                        break;

                    case OpCodes.RNC:
                        OpCode(sb, "RNC");
                        break;
                    case OpCodes.POP_D:
                        OpCode(sb, "POP", "D");
                        break;
                    case OpCodes.JNC:
                        OpCodeAddress(sb, stream, "JNC");
                        break;
                    case OpCodes.OUT:
                        OpCode8(sb, stream, "OUT");
                        break;
                    case OpCodes.CNC:
                        OpCodeAddress(sb, stream, "CNC");
                        break;
                    case OpCodes.PUSH_D:
                        OpCode(sb, "PUSH", "D");
                        break;
                    case OpCodes.SUI:
                        OpCode8(sb, stream, "SUI");
                        break;
                    case OpCodes.RST_2:
                        OpCode(sb, "RST", "2");
                        break;
                    case OpCodes.RC:
                        OpCode(sb, "RC");
                        break;


                    case OpCodes.JC:
                        OpCodeAddress(sb, stream, "JC");
                        break;
                    case OpCodes.IN:
                        OpCode8(sb, stream, "IN");
                        break;
                    case OpCodes.CC:
                        OpCodeAddress(sb, stream, "CC");
                        break;


                    case OpCodes.SBI:
                        OpCode8(sb, stream, "SBI");
                        break;
                    case OpCodes.RST_3:
                        OpCode(sb, "RST", "3");
                        break;

                    case OpCodes.RPO:
                        OpCode(sb, "RPO");
                        break;
                    case OpCodes.POP_H:
                        OpCode(sb, "POP", "H");
                        break;
                    case OpCodes.JPO:
                        OpCodeAddress(sb, stream, "JPO");
                        break;
                    case OpCodes.XTHL:
                        OpCode(sb, "XTHL");
                        break;
                    case OpCodes.CPO:
                        OpCodeAddress(sb, stream, "CPO");
                        break;
                    case OpCodes.PUSH_H:
                        OpCode(sb, "PUSH", "H");
                        break;
                    case OpCodes.ANI:
                        OpCode8(sb, stream, "ANI");
                        break;
                    case OpCodes.RST_4:
                        OpCode(sb, "RST", "4");
                        break;
                    case OpCodes.RPE:
                        OpCode(sb, "RPE");
                        break;
                    case OpCodes.PCHL:
                        OpCode(sb, "PCHL");
                        break;
                    case OpCodes.JPE:
                        OpCodeAddress(sb, stream, "JPE");
                        break;
                    case OpCodes.XCHG:
                        OpCode(sb, "XCHG");
                        break;
                    case OpCodes.CPE:
                        OpCodeAddress(sb, stream, "CPE");
                        break;


                    case OpCodes.XRI:
                        OpCode8(sb, stream, "XRI");
                        break;
                    case OpCodes.RST_5:
                        OpCode(sb, "RST", "5");
                        break;

                    case OpCodes.RP:
                        OpCode(sb, "RP");
                        break;
                    case OpCodes.POP_PSW:
                        OpCode(sb, "POP", "PSW");
                        break;
                    case OpCodes.JP:
                        OpCodeAddress(sb, stream, "JP");
                        break;
                    case OpCodes.DI:
                        OpCode(sb, "DI");
                        break;
                    case OpCodes.CP:
                        OpCodeAddress(sb, stream, "CP");
                        break;
                    case OpCodes.PUSH_PSW:
                        OpCode(sb, "PUSH", "PSW");
                        break;
                    case OpCodes.ORI:
                        OpCode8(sb, stream, "ORI");
                        break;
                    case OpCodes.RST_6:
                        OpCode(sb, "RST", "6");
                        break;
                    case OpCodes.RM:
                        OpCode(sb, "RM");
                        break;
                    case OpCodes.SPHL:
                        OpCode(sb, "SPHL");
                        break;
                    case OpCodes.JM:
                        OpCodeAddress(sb, stream, "JM");
                        break;
                    case OpCodes.EI:
                        OpCode(sb, "EI");
                        break;
                    case OpCodes.CM:
                        OpCodeAddress(sb, stream, "CM");
                        break;


                    case OpCodes.CPI:
                        OpCode8(sb, stream, "CPI");
                        break;
                    case OpCodes.RST_7:
                        OpCode(sb, "RST", "7");
                        break;

                        //default:
                        //throw new NotImplementedException();
                }

            }

            return sb.ToString();


        }

        private static void OpCodeAddress(StringBuilder sb, Stream stream, string opCode)
        {
            sb.AppendLine(String.Format("{0}\t{2}{1}H", opCode, stream.ReadByte().ToString("X2"), stream.ReadByte().ToString("X2")));
        }
        private static void OpCode16(StringBuilder sb, Stream stream, string opCode)
        {
            sb.AppendLine(String.Format("{0}\t{2}{1}H", opCode, stream.ReadByte().ToString("X2"), stream.ReadByte().ToString("X2")));
        }

        private static void OpCode16(StringBuilder sb, Stream stream, string opCode, string operand)
        {
            sb.AppendLine(String.Format("{0}\t{1}\t{3}{2}H", opCode, operand, stream.ReadByte().ToString("X2"), stream.ReadByte().ToString("X2")));
        }

        private static void OpCode8(StringBuilder sb, Stream stream, string opCode)
        {
            sb.AppendLine(String.Format("{0}\t{1}H", opCode, stream.ReadByte().ToString("X2")));
        }

        private static void OpCode8(StringBuilder sb, Stream stream, string opCode, string operand)
        {
            sb.AppendLine(String.Format("{0}\t{1}\t{2}H", opCode, operand, stream.ReadByte().ToString("X2")));
        }

        private static void OpCode(StringBuilder sb, string opCode, string operand)
        {
            sb.AppendLine(String.Format("{0}\t{1}", opCode, operand));
        }

        private static void OpCode(StringBuilder sb, string opCode)
        {
            sb.AppendLine(opCode);
        }

    }
}
