using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel8080.Tools;

namespace Intel8080
{
    public class Emulator
    {
        //counters
        public int ProgramCounter = 0;
        public int StackCounter = 0;

        //registers
        public byte B;
        public byte C;
        public byte D;
        public byte E;
        public byte H;
        public byte L;
        public byte M;
        public byte A;

        //flags
        public bool Carry;
        public bool Parity;
        public bool Sign;
        public bool Zero;

        private Stopwatch stopwatch = new Stopwatch();
        private const int ticksPerCycle = 5;

        private byte[] ROM = new byte[8192];
        private byte[] RAM = new byte[2048];

        private long currentCycle = 0;
        private long nextOpCycle = 0;

        public void Execute()
        {
            stopwatch.Start();

            while (true)
            {
                //sequence CPU cycles to occur ever 5 ticks to give a 2Mhz clock speed
                if (stopwatch.ElapsedTicks > ticksPerCycle * currentCycle)
                {
                    //operations can take more than one cycle
                    //this causes the cpu to wait the required number of cycles
                    //based upon the operation
                    if (nextOpCycle == currentCycle)
                    {
                        var operationCycles = NextStep();
                        nextOpCycle = currentCycle + operationCycles;
                    }


                    //Temporary clocking to verify we are hitting our target rates
                    //This pauses execution to display these metrics and should absolutely
                    //be removed before actual use.
                    if (stopwatch.ElapsedTicks >= TimeSpan.TicksPerSecond)
                    {
                        Console.WriteLine(String.Format("PC:{0} Mhz:{1:0.00}", ProgramCounter, currentCycle / 1000000.0));
                        currentCycle = 0;
                        nextOpCycle = 0;
                        stopwatch.Restart();

                    }
                    else
                    {
                        currentCycle++;
                    }
                }
            }
        }



        private int NextStep()
        {
            int opCode = ROM[0];
            int cycles = 1;

            switch ((byte)opCode)
            {
                case OpCodes.NOP:
                    cycles = 4;
                    break;

                case OpCodes.LXI_B:
                case OpCodes.STAX_B:
                case OpCodes.INX_B:
                case OpCodes.INR_B:
                case OpCodes.DCR_B:
                case OpCodes.MVI_B:
                case OpCodes.RLC:

                case OpCodes.DAD_B:
                case OpCodes.LDAX_B:
                case OpCodes.DCX_B:
                case OpCodes.INR_C:
                case OpCodes.DCR_C:
                case OpCodes.MVI_C:
                case OpCodes.RRC:

                case OpCodes.LXI_D:
                case OpCodes.STAX_D:
                case OpCodes.INX_D:
                case OpCodes.INR_D:
                case OpCodes.DCR_D:
                case OpCodes.MVI_D:
                case OpCodes.RAL:

                case OpCodes.DAD_D:
                case OpCodes.LDAX_D:
                case OpCodes.DCX_D:
                case OpCodes.INR_E:
                case OpCodes.DCR_E:
                case OpCodes.MVI_E:
                case OpCodes.RAR:

                case OpCodes.LXI_H:
                case OpCodes.SHLD:
                case OpCodes.INX_H:
                case OpCodes.INR_H:
                case OpCodes.DCR_H:
                case OpCodes.MVI_H:
                case OpCodes.DAA:

                case OpCodes.DAD_H:
                case OpCodes.LHLD:
                case OpCodes.DCX_H:
                case OpCodes.INR_L:
                case OpCodes.DCR_L:
                case OpCodes.MVI_L:
                case OpCodes.CMA:

                case OpCodes.LXI_SP:
                case OpCodes.STA:
                case OpCodes.INX_SP:
                case OpCodes.INR_M:
                case OpCodes.DCR_M:
                case OpCodes.MVI_M:
                case OpCodes.STC:

                case OpCodes.DAD_SP:
                case OpCodes.LDA:
                case OpCodes.DCX_SP:
                case OpCodes.INR_A:
                case OpCodes.DCR_A:
                case OpCodes.MVI_A:
                case OpCodes.CMC:

                case OpCodes.MOV_B_B:
                case OpCodes.MOV_B_C:
                case OpCodes.MOV_B_D:
                case OpCodes.MOV_B_E:
                case OpCodes.MOV_B_H:
                case OpCodes.MOV_B_L:
                case OpCodes.MOV_B_M:
                case OpCodes.MOV_B_A:

                case OpCodes.MOV_C_B:
                case OpCodes.MOV_C_C:
                case OpCodes.MOV_C_D:
                case OpCodes.MOV_C_E:
                case OpCodes.MOV_C_H:
                case OpCodes.MOV_C_L:
                case OpCodes.MOV_C_M:
                case OpCodes.MOV_C_A:

                case OpCodes.MOV_D_B:
                case OpCodes.MOV_D_C:
                case OpCodes.MOV_D_D:
                case OpCodes.MOV_D_E:
                case OpCodes.MOV_D_H:
                case OpCodes.MOV_D_L:
                case OpCodes.MOV_D_M:
                case OpCodes.MOV_D_A:

                case OpCodes.MOV_E_B:
                case OpCodes.MOV_E_C:
                case OpCodes.MOV_E_D:
                case OpCodes.MOV_E_E:
                case OpCodes.MOV_E_H:
                case OpCodes.MOV_E_L:
                case OpCodes.MOV_E_M:
                case OpCodes.MOV_E_A:

                case OpCodes.MOV_H_B:
                case OpCodes.MOV_H_C:
                case OpCodes.MOV_H_D:
                case OpCodes.MOV_H_E:
                case OpCodes.MOV_H_H:
                case OpCodes.MOV_H_L:
                case OpCodes.MOV_H_M:
                case OpCodes.MOV_H_A:

                case OpCodes.MOV_L_B:
                case OpCodes.MOV_L_C:
                case OpCodes.MOV_L_D:
                case OpCodes.MOV_L_E:
                case OpCodes.MOV_L_H:
                case OpCodes.MOV_L_L:
                case OpCodes.MOV_L_M:
                case OpCodes.MOV_L_A:

                case OpCodes.MOV_M_B:
                case OpCodes.MOV_M_C:
                case OpCodes.MOV_M_D:
                case OpCodes.MOV_M_E:
                case OpCodes.MOV_M_H:
                case OpCodes.MOV_M_L:
                case OpCodes.HLT:
                case OpCodes.MOV_M_A:

                case OpCodes.MOV_A_B:
                case OpCodes.MOV_A_C:
                case OpCodes.MOV_A_D:
                case OpCodes.MOV_A_E:
                case OpCodes.MOV_A_H:
                case OpCodes.MOV_A_L:
                case OpCodes.MOV_A_M:
                case OpCodes.MOV_A_A:

                case OpCodes.ADD_B:
                case OpCodes.ADD_C:
                case OpCodes.ADD_D:
                case OpCodes.ADD_E:
                case OpCodes.ADD_H:
                case OpCodes.ADD_L:
                case OpCodes.ADD_M:
                case OpCodes.ADD_A:

                case OpCodes.ADC_B:
                case OpCodes.ADC_C:
                case OpCodes.ADC_D:
                case OpCodes.ADC_E:
                case OpCodes.ADC_H:
                case OpCodes.ADC_L:
                case OpCodes.ADC_M:
                case OpCodes.ADC_A:

                case OpCodes.SUB_B:
                case OpCodes.SUB_C:
                case OpCodes.SUB_D:
                case OpCodes.SUB_E:
                case OpCodes.SUB_H:
                case OpCodes.SUB_L:
                case OpCodes.SUB_M:
                case OpCodes.SUB_A:

                case OpCodes.SBB_B:
                case OpCodes.SBB_C:
                case OpCodes.SBB_D:
                case OpCodes.SBB_E:
                case OpCodes.SBB_H:
                case OpCodes.SBB_L:
                case OpCodes.SBB_M:
                case OpCodes.SBB_A:

                case OpCodes.ANA_B:
                case OpCodes.ANA_C:
                case OpCodes.ANA_D:
                case OpCodes.ANA_E:
                case OpCodes.ANA_H:
                case OpCodes.ANA_L:
                case OpCodes.ANA_M:
                case OpCodes.ANA_A:

                case OpCodes.XRA_B:
                case OpCodes.XRA_C:
                case OpCodes.XRA_D:
                case OpCodes.XRA_E:
                case OpCodes.XRA_H:
                case OpCodes.XRA_L:
                case OpCodes.XRA_M:
                case OpCodes.XRA_A:

                case OpCodes.ORA_B:
                case OpCodes.ORA_C:
                case OpCodes.ORA_D:
                case OpCodes.ORA_E:
                case OpCodes.ORA_H:
                case OpCodes.ORA_L:
                case OpCodes.ORA_M:
                case OpCodes.ORA_A:

                case OpCodes.CMP_B:
                case OpCodes.CMP_C:
                case OpCodes.CMP_D:
                case OpCodes.CMP_E:
                case OpCodes.CMP_H:
                case OpCodes.CMP_L:
                case OpCodes.CMP_M:
                case OpCodes.CMP_A:

                case OpCodes.RNZ:
                case OpCodes.POP_B:
                case OpCodes.JNZ:
                case OpCodes.JMP:
                case OpCodes.CNZ:
                case OpCodes.PUSH_B:
                case OpCodes.ADI:
                case OpCodes.RST_0:
                case OpCodes.RZ:
                case OpCodes.RET:
                case OpCodes.JZ:

                case OpCodes.CZ:
                case OpCodes.CALL:
                case OpCodes.ACI:
                case OpCodes.RST_1:

                case OpCodes.RNC:
                case OpCodes.POP_D:
                case OpCodes.JNC:
                case OpCodes.OUT:
                case OpCodes.CNC:
                case OpCodes.PUSH_D:
                case OpCodes.SUI:
                case OpCodes.RST_2:
                case OpCodes.RC:

                case OpCodes.JC:
                case OpCodes.IN:
                case OpCodes.CC:

                case OpCodes.SBI:
                case OpCodes.RST_3:

                case OpCodes.RPO:
                case OpCodes.POP_H:
                case OpCodes.JPO:
                case OpCodes.XTHL:
                case OpCodes.CPO:
                case OpCodes.PUSH_H:
                case OpCodes.ANI:
                case OpCodes.RST_4:
                case OpCodes.RPE:
                case OpCodes.PCHL:
                case OpCodes.JPE:
                case OpCodes.XCHG:
                case OpCodes.CPE:

                case OpCodes.XRI:
                case OpCodes.RST_5:

                case OpCodes.RP:
                case OpCodes.POP_PSW:
                case OpCodes.JP:
                case OpCodes.DI:
                case OpCodes.CP:
                case OpCodes.PUSH_PSW:
                case OpCodes.ORI:
                case OpCodes.RST_6:
                case OpCodes.RM:
                case OpCodes.SPHL:
                case OpCodes.JM:
                case OpCodes.EI:
                case OpCodes.CM:

                case OpCodes.CPI:
                case OpCodes.RST_7:
                    throw new NotImplementedException();
            }

            ProgramCounter++;
            return cycles;

        }

    }
}
