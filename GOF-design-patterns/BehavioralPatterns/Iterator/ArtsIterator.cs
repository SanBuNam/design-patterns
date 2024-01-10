using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns.Iterator
{
    public class ArtsIterator : IIterator
    {
        private string[] Subjects;
        private int position;
        public ArtsIterator(string[] subjects)
        {
            this.Subjects = subjects;
            position = 0;
        }
        public void First()
        {
            position = 0;
        }
        public string Next()
        {
            return Subjects[position++];
        }
        public bool IsDone()
        {
            if (position < Subjects.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string CurrentItem()
        {
            return Subjects[position];
        }
    }
}
