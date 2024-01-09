using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns.TemplateMethod
{
    public abstract class BasicEngineering
    {
        public void Papers()
        {
            // Common Papers;
            Math();
            SoftSkills();
            // Specialized Paper:
            SpecialPaper();
        }
        private void Math()
        {
            Console.WriteLine("Mathematics");
        }
        private void SoftSkills()
        {
            Console.WriteLine("SoftSkills");
        }
        public abstract void SpecialPaper();
    }
}
