using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns.TemplateMethod
{
    public class Electronics : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("Digital Logic and Circuit Theory");
        }
    }
}
