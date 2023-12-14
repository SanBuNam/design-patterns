using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GOF_design_patterns.StructuralPatterns;

namespace GOF_design_patterns
{
    interface IRobot
    {
        void Print();
    }
    // ConcreteFlyweight
    class Robot : IRobot
    {
        String robotType;
        public String colorOfRobot;
        public Robot(String robotType)
        {
            this.robotType = robotType;
        }
        public void SetColor(String colorOfRobot)
        {
            this.colorOfRobot = colorOfRobot;
        }
        public void Print()
        {
            Console.WriteLine("This is a" + robotType + "type robot with" + colorOfRobot + "color");
        }
    }

    // FlyweightFactory
    class RobotFactory
    {
        Dictionary<string, IRobot> shapes = new Dictionary<string, IRobot>();
        public int TotalObjectsCreated()
        {
            return shapes.Count;
        }

        public IRobot GetRobotFromFactory(String robotType)
        {
            IRobot robotCategory = null;
            if (shapes.ContainsKey(robotType))
            {
                robotCategory = shapes[robotType];
            }
            else
            {
                switch(robotType)
                {
                    case "Small":
                        robotCategory = new Robot("Small");
                        shapes.Add("Small", robotCategory);
                        break;
                    case "Large":
                        robotCategory = new Robot("Large");
                        shapes.Add("Large", robotCategory);
                        break;
                    default:
                        throw new Exception("Robot Factory can create only one each type robot");
                }
            }
            return robotCategory;
        }
    }

    // Flyweight pattern is in action
    class Program
    {
        static void Main(string[] args)
        {
            RobotFactory myfactory = new RobotFactory();
            Robot shape;
            for (int i = 0; i < 3; i++)
            {
                shape = (Robot)myfactory.GetRobotFromFactory("Small");
                Thread.Sleep(1000);
                shape.SetColor(getRandomColor());
                shape.Print();
            }
            for (int i = 0; i < 3; i++)
            {
                shape = (Robot)myfactory.GetRobotFromFactory("Large");
                Thread.Sleep(1000);
                shape.SetColor(getRandomColor());
                shape.Print();
            }
            int NumOfDistinctRobots = myfactory.TotalObjectsCreated();
            Console.WriteLine("\n Finally no of Distinct Robot objects created: " + NumOfDistinctRobots);
            Console.ReadKey();
        }

        private static string getRandomColor()
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
