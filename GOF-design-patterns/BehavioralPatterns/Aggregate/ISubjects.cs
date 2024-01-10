using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOF_design_patterns.BehavioralPatterns.Iterator;

namespace GOF_design_patterns.BehavioralPatterns.Aggregate
{
    public interface ISubjects
    {
        IIterator CreateIterator();
    }
}
