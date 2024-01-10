using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GOF_design_patterns.BehavioralPatterns.Aggregate;
using GOF_design_patterns.BehavioralPatterns.Iterator;


namespace GOF_design_patterns
{
    // Iterator pattern
    // Definition: Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
    class IteratorProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Iterator Pattern Demo***");
            ISubjects ScienceSubjects = new Science();
            ISubjects ArtsSubjects = new Arts();
            IIterator IteratorForScience = ScienceSubjects.CreateIterator();
            IIterator IteratorForArts = ArtsSubjects.CreateIterator();
            Console.WriteLine("\nScience subjects :");
            Print(IteratorForScience);
            Console.WriteLine("\nArts subjects :");
            Print(IteratorForArts);
            Console.ReadLine();
        }

        private static void Print(IIterator iterator)
        {
            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
