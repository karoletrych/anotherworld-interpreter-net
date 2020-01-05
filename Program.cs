using System;
using System.IO;

namespace anotherworld_interpreter_net
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            new BytecodeReader().Read();
        }
    }
}
