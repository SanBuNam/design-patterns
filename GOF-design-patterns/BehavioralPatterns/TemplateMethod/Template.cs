using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns.TemplateMethod
{
    class TemplateProgram
    {
        static void TemplateMain(string[] args)
        {
            Console.WriteLine("***Template Method Pattern Demo***\n");

            BasicEngineering bs = new ComputerScience();

            Console.WriteLine("Computer Sc Papers:");
            bs.Papers();
            Console.WriteLine();

            bs = new Electronics();
            Console.WriteLine("Electronics Papers");
            bs.Papers();
            Console.ReadLine();
        }
    }
}
