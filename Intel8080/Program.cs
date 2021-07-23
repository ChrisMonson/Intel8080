using Intel8080.Tools;
using System;
using System.IO;

namespace Intel8080
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new FileStream("roms\\invaders.h", FileMode.Open);
            Console.WriteLine(Disassembler.Execute(stream));
        }
    }
}
