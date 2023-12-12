using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOF_design_patterns.StructuralPatterns.RobotParts;

namespace GOF_design_patterns.StructuralPatterns
{
    public class RobotFacade
    {
        RobotColor rc;
        RobotHands rh;
        RobotBody rb;

        public RobotFacade()
        {
            rc = new RobotColor();
            rh = new RobotHands();
            rb = new RobotBody();
        }
        public void ConstructMilanoRobot()
        {
            Console.WriteLine("Creation of a Milano Robot Start");
            rc.SetDefaultColor();
            rh.SetMilanoHands();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine("Milano Robot Creation End");
            Console.WriteLine();
        }
        public void ConstructRobonautRobot() 
        {
            Console.WriteLine("Initiating the creational process of a Robonaut Robot");
            rc.SetGreenColor();
            rh.SetRobonautHands();
            rb.CreateHands();
            rb.CreateRemainingParts();
            Console.WriteLine("A Robonaut Robot is created");
            Console.WriteLine();
        }
        public void DestroyMilanoRobot()
        {
            Console.WriteLine("Milano robot's destruction process is started");
            rh.ResetMilanoHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine("Milano Robot's destruction process is over");
            Console.WriteLine();
        }
        public void DestroyRobonautRobot()
        {
            Console.WriteLine("Initiating a Robonaut Robot's destruction process.");
            rh.ResetRobonautHands();
            rb.DestroyHands();
            rb.DestroyRemainingParts();
            Console.WriteLine("A Robonaut Robot is destroyed");
            Console.WriteLine();
        }
    }
    class FacadeProgram
    {
        static void FacadeMain(string[] args)
        {
            Console.WriteLine("***Facade Pattern Demo***\n");
            //Creating Robots
            RobotFacade rf1 = new RobotFacade();
            rf1.ConstructMilanoRobot();
            RobotFacade rf2 = new RobotFacade();
            rf2.ConstructRobonautRobot();
            // Destroying robots
            rf1.DestroyMilanoRobot();
            rf2.DestroyRobonautRobot();
            Console.ReadLine();
        }
    }
}
