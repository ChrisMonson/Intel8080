using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel8080.Tools
{
    public static class OpCodes
    {

        public const byte NOP = 0x00;
        public const byte LXI_B = 0x01;
        public const byte STAX_B = 0x02;
        public const byte INX_B = 0x03;
        public const byte INR_B = 0x04;
        public const byte DCR_B = 0x05;
        public const byte MVI_B = 0x06;
        public const byte RLC = 0x07;
         
        public const byte DAD_B = 0x09;
        public const byte LDAX_B = 0x0A;
        public const byte DCX_B = 0x0B;        
        public const byte INR_C = 0x0C;
        public const byte DCR_C = 0x0D;
        public const byte MVI_C = 0x0E;
        public const byte RRC = 0x0F;
         
        public const byte LXI_D = 0x11;
        public const byte STAX_D = 0x12;
        public const byte INX_D = 0x13;
        public const byte INR_D = 0x14;
        public const byte DCR_D = 0x15;
        public const byte MVI_D = 0x16;
        public const byte RAL = 0x17;
         
        public const byte DAD_D = 0x19;
        public const byte LDAX_D = 0x1A;
        public const byte DCX_D = 0x1B;
        public const byte INR_E = 0x1C;
        public const byte DCR_E = 0x1D;
        public const byte MVI_E = 0x1E;
        public const byte RAR = 0x1F;
         
        public const byte LXI_H = 0x21;
        public const byte SHLD = 0x22;
        public const byte INX_H = 0x23;
        public const byte INR_H = 0x24;
        public const byte DCR_H = 0x25;
        public const byte MVI_H = 0x26;
        public const byte DAA = 0x27;
         
        public const byte DAD_H = 0x29;
        public const byte LHLD = 0x2A;
        public const byte DCX_H = 0x2B;
        public const byte INR_L = 0x2C;
        public const byte DCR_L = 0x2D;
        public const byte MVI_L = 0x2E;
        public const byte CMA = 0x2F;
         
        public const byte LXI_SP = 0x31;
        public const byte STA = 0x32;
        public const byte INX_SP = 0x33;
        public const byte INR_M = 0x34;
        public const byte DCR_M = 0x35;
        public const byte MVI_M = 0x36;
        public const byte STC = 0x37;
         
        public const byte DAD_SP = 0x39;
        public const byte LDA = 0x3A;
        public const byte DCX_SP = 0x3B;
        public const byte INR_A = 0x3C;
        public const byte DCR_A = 0x3D;
        public const byte MVI_A = 0x3E;
        public const byte CMC = 0x3F;
         
        public const byte MOV_B_B = 0x40;
        public const byte MOV_B_C = 0x41;
        public const byte MOV_B_D = 0x42;
        public const byte MOV_B_E = 0x43;
        public const byte MOV_B_H = 0x44;
        public const byte MOV_B_L = 0x45;
        public const byte MOV_B_M = 0x46;
        public const byte MOV_B_A = 0x47;
         
        public const byte MOV_C_B = 0x48;
        public const byte MOV_C_C = 0x49;
        public const byte MOV_C_D = 0x4A;
        public const byte MOV_C_E = 0x4B;
        public const byte MOV_C_H = 0x4C;
        public const byte MOV_C_L = 0x4D;
        public const byte MOV_C_M = 0x4E;
        public const byte MOV_C_A = 0x4F;
         
        public const byte MOV_D_B = 0x50;
        public const byte MOV_D_C = 0x51;
        public const byte MOV_D_D = 0x52;
        public const byte MOV_D_E = 0x53;
        public const byte MOV_D_H = 0x54;
        public const byte MOV_D_L = 0x55;
        public const byte MOV_D_M = 0x56;
        public const byte MOV_D_A = 0x57;
         
        public const byte MOV_E_B = 0x58;
        public const byte MOV_E_C = 0x59;
        public const byte MOV_E_D = 0x5A;
        public const byte MOV_E_E = 0x5B;
        public const byte MOV_E_H = 0x5C;
        public const byte MOV_E_L = 0x5D;
        public const byte MOV_E_M = 0x5E;
        public const byte MOV_E_A = 0x5F;
         
        public const byte MOV_H_B = 0x60;
        public const byte MOV_H_C = 0x61;
        public const byte MOV_H_D = 0x62;
        public const byte MOV_H_E = 0x63;
        public const byte MOV_H_H = 0x64;
        public const byte MOV_H_L = 0x65;
        public const byte MOV_H_M = 0x66;
        public const byte MOV_H_A = 0x67;
         
        public const byte MOV_L_B = 0x68;
        public const byte MOV_L_C = 0x69;
        public const byte MOV_L_D = 0x6A;
        public const byte MOV_L_E = 0x6B;
        public const byte MOV_L_H = 0x6C;
        public const byte MOV_L_L = 0x6D;
        public const byte MOV_L_M = 0x6E;
        public const byte MOV_L_A = 0x6F;
         
        public const byte MOV_M_B = 0x70;
        public const byte MOV_M_C = 0x71;
        public const byte MOV_M_D = 0x72;
        public const byte MOV_M_E = 0x73;
        public const byte MOV_M_H = 0x74;
        public const byte MOV_M_L = 0x75;
        public const byte HLT = 0x76;
        public const byte MOV_M_A = 0x77;
         
        public const byte MOV_A_B = 0x78;
        public const byte MOV_A_C = 0x79;
        public const byte MOV_A_D = 0x7A;
        public const byte MOV_A_E = 0x7B;
        public const byte MOV_A_H = 0x7C;
        public const byte MOV_A_L = 0x7D;
        public const byte MOV_A_M = 0x7E;
        public const byte MOV_A_A = 0x7F;
         
        public const byte ADD_B = 0x80;
        public const byte ADD_C = 0x81;
        public const byte ADD_D = 0x82;
        public const byte ADD_E = 0x83;
        public const byte ADD_H = 0x84;
        public const byte ADD_L = 0x85;
        public const byte ADD_M = 0x86;
        public const byte ADD_A = 0x87;
         
        public const byte ADC_B = 0x88;
        public const byte ADC_C = 0x89;
        public const byte ADC_D = 0x8A;
        public const byte ADC_E = 0x8B;
        public const byte ADC_H = 0x8C;
        public const byte ADC_L = 0x8D;
        public const byte ADC_M = 0x8E;
        public const byte ADC_A = 0x8F;
         
        public const byte SUB_B = 0x90;
        public const byte SUB_C = 0x91;
        public const byte SUB_D = 0x92;
        public const byte SUB_E = 0x93;
        public const byte SUB_H = 0x94;
        public const byte SUB_L = 0x95;
        public const byte SUB_M = 0x96;
        public const byte SUB_A = 0x97;
         
        public const byte SBB_B = 0x98;
        public const byte SBB_C = 0x99;
        public const byte SBB_D = 0x9A;
        public const byte SBB_E = 0x9B;
        public const byte SBB_H = 0x9C;
        public const byte SBB_L = 0x9D;
        public const byte SBB_M = 0x9E;
        public const byte SBB_A = 0x9F;
         
        public const byte ANA_B = 0xA0;
        public const byte ANA_C = 0xA1;
        public const byte ANA_D = 0xA2;
        public const byte ANA_E = 0xA3;
        public const byte ANA_H = 0xA4;
        public const byte ANA_L = 0xA5;
        public const byte ANA_M = 0xA6;
        public const byte ANA_A = 0xA7;
         
        public const byte XRA_B = 0xA8;
        public const byte XRA_C = 0xA9;
        public const byte XRA_D = 0xAA;
        public const byte XRA_E = 0xAB;
        public const byte XRA_H = 0xAC;
        public const byte XRA_L = 0xAD;
        public const byte XRA_M = 0xAE;
        public const byte XRA_A = 0xAF;
         
        public const byte ORA_B = 0xB0;
        public const byte ORA_C = 0xB1;
        public const byte ORA_D = 0xB2;
        public const byte ORA_E = 0xB3;
        public const byte ORA_H = 0xB4;
        public const byte ORA_L = 0xB5;
        public const byte ORA_M = 0xB6;
        public const byte ORA_A = 0xB7;
                              
        public const byte CMP_B = 0xB8;
        public const byte CMP_C = 0xB9;
        public const byte CMP_D = 0xBA;
        public const byte CMP_E = 0xBB;
        public const byte CMP_H = 0xBC;
        public const byte CMP_L = 0xBD;
        public const byte CMP_M = 0xBE;
        public const byte CMP_A = 0xBF;
         
        public const byte RNZ = 0xC0;
        public const byte POP_B = 0xC1;
        public const byte JNZ = 0xC2;
        public const byte JMP = 0xC3;
        public const byte CNZ = 0xC4;
        public const byte PUSH_B = 0xC5;
        public const byte ADI = 0xC6;
        public const byte RST_0 = 0xC7;
        public const byte RZ = 0xC8;
        public const byte RET = 0xC9;
        public const byte JZ = 0xCA;
         
        public const byte CZ = 0xCC;
        public const byte CALL = 0xCD;
        public const byte ACI = 0xCE;
        public const byte RST_1 = 0xCF;
         
        public const byte RNC = 0xD0;
        public const byte POP_D = 0xD1;
        public const byte JNC = 0xD2;
        public const byte OUT = 0xD3;
        public const byte CNC = 0xD4;
        public const byte PUSH_D = 0xD5;
        public const byte SUI = 0xD6;
        public const byte RST_2 = 0xD7;
        public const byte RC = 0xD8;
         
        public const byte JC = 0xDA;
        public const byte IN = 0xDB;
        public const byte CC = 0xDC;
         
        public const byte SBI = 0xDE;
        public const byte RST_3 = 0xDF;
         
        public const byte RPO = 0xE0;
        public const byte POP_H = 0xE1;
        public const byte JPO = 0xE2;
        public const byte XTHL = 0xE3;
        public const byte CPO = 0xE4;
        public const byte PUSH_H = 0xE5;
        public const byte ANI = 0xE6;
        public const byte RST_4 = 0xE7;
        public const byte RPE = 0xE8;
        public const byte PCHL = 0xE9;
        public const byte JPE = 0xEA;
        public const byte XCHG = 0xEB;
        public const byte CPE = 0xEC;
         
        public const byte XRI = 0xEE;
        public const byte RST_5 = 0xEF;
         
        public const byte RP = 0xF0;
        public const byte POP_PSW = 0xF1;
        public const byte JP = 0xF2;
        public const byte DI = 0xF3;
        public const byte CP = 0xF4;
        public const byte PUSH_PSW = 0xF5;
        public const byte ORI = 0xF6;
        public const byte RST_6 = 0xF7;
        public const byte RM = 0xF8;
        public const byte SPHL = 0xF9;
        public const byte JM = 0xFA;
        public const byte EI = 0xFB;
        public const byte CM = 0xFC;
         
        public const byte CPI = 0xFE;
        public const byte RST_7 = 0xFF;

    }
}
