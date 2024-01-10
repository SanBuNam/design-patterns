using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns.Iterator
{
    public interface IIterator
    {
        void First(); //Reset to first element
        string Next(); //Get next element
        bool IsDone(); //End of collection check
        string CurrentItem(); //Retrieve Current Item
    }
}
