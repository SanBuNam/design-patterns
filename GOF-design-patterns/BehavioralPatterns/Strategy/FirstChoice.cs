﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns.Strategy
{
    public class FirstChoice : IChoice
    {
        public void MyChoice()
        {
            Console.WriteLine("Traveling to Japan");
        }
    }
}
