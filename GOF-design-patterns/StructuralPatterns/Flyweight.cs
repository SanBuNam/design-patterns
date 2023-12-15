using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GOF_design_patterns.StructuralPatterns
{
    interface IRobot
    {
        void Print();
    }

    public class Robot : IRobot
    {
        String robotType;
        public string colorOfRobot;
        public Robot(String robotType)
        {
            this.robotType = robotType;
        }
        public void setColor(String colorOfRobot)
        {
            this.colorOfRobot = colorOfRobot;
        }
        public void Print()
        {
            Console.WriteLine("This is a" + robotType + "type robot with" + colorOfRobot + "color");
        }
    }

    class RobotFactory
    {
        Dictionary<string, IRobot> theOne = new Dictionary<string, IRobot>();
        public int TotalObjectsCreated()
        {
            return theOne.Count;
        }

        public IRobot GetRobotFromFactory(String robotType)
        {
            IRobot robotCategory = null;
            if (theOne.ContainsKey(robotType))
            {
                robotCategory = theOne[robotType];
            }
            else
            {
                switch(robotType)
                {
                    case "Small":
                        robotCategory = new Robot("Small");
                        theOne.Add("Small", robotCategory);
                        break;
                    case "Large":
                        robotCategory = new Robot("Large");
                        theOne.Add("Large", robotCategory);
                        break;
                    default:
                        throw new Exception("Robot Factory can create only one each type robot");
                }
            }
            return robotCategory;
        }
    }

    class FlyweightProgram
    {
        static void FlyweightMain(string[] args)
        {
            RobotFactory myfactory = new RobotFactory();
            Robot one;
            for (int i = 0; i < 3; i++)
            {
                one = (Robot)myfactory.GetRobotFromFactory("Small");
                Thread.Sleep(1000);
                one.setColor(getRandomColor());
                one.Print();
            }
            for (int i = 0; i < 3; i++)
            {
                one = (Robot)myfactory.GetRobotFromFactory("Large");
                Thread.Sleep(1000);
                one.setColor(getRandomColor());
                one.Print();
            }
            int NumOfDistinctRobots = myfactory.TotalObjectsCreated();
            Console.WriteLine("\n Finally no of Distinct Robot objects created: " + NumOfDistinctRobots);
            Console.ReadKey();
        }

        static string getRandomColor()
        {
            Random r = new Random();
            int random = r.Next(1000);
            if (random % 2 == 0)
            {
                return "red";
            }
            else
            {
                return "green";
            }
        }
    }
}
