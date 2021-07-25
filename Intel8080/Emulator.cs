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
            }

            ProgramCounter++;
            return cycles;

        }

    }
}
