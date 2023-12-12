using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.StructuralPatterns.RobotParts
{
    public class RobotColor
    {
        public void SetDefaultColor()
        {
            Console.WriteLine("This is steel color robot.");
        }
        public void SetGreenColor()
        {
            Console.WriteLine("This is a green color robot.");
        }
    }
}
