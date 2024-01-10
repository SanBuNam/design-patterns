using GOF_design_patterns.BehavioralPatterns.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns.Aggregate
{
    public class Arts : ISubjects
    {
        private string[] Subjects;
        public Arts()
        {
            Subjects = new[] { "Bengali", "English" };
        }
        public IIterator CreateIterator()
        {
            return new ArtsIterator(Subjects);
        }
    }
}
