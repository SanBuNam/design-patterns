using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GOF_design_patterns.BehavioralPatterns.Aggregate;
using GOF_design_patterns.BehavioralPatterns.Iterator;


namespace GOF_design_patterns
{
    /*
     Null Object pattern
     In object-oriented computer programming, a null object is an object with no referenced value or with defined neutral ('null') behavior.
     The null object design pattern describes the uses of such objects and their behavior (or lack thereof).
     
     Concept:
     The pattern can implement a "do-nothing" relationship, or it can provide a default behavior when an application encounters a null object instead of a real object.
     In simple words, the core aim is to make a better solution by avoiding a "null objects check" or "null collaborations check" through if blocks.
     To explain the concept better, I will explain the problems associated with the following program (which is basically a faulty program), 
     analyze the probable solutions, and ultimately, implement the concept of this design pattern.
     */
    
    //Faulty Program
    //interface IVehicle
    //{
    //    void Travel();
    //}
    //class Bus : IVehicle
    //{
    //    public static int busCount = 0;
    //    public Bus()
    //    {
    //        busCount++;
    //    }
    //    public void Travel()
    //    {
    //        Console.WriteLine("Let us travel with Bus");
    //    }
    //}
    //class Train : IVehicle
    //{
    //    public static int trainCount = 0;
    //    public Train()
    //    {
    //        trainCount++;
    //    }
    //    public void Travel()
    //    {
    //        Console.WriteLine("Let us travel with Train");
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("*** Null Object Pattern ***\n");
    //        string input = String.Empty;
    //        int totalObjects = 0;
    //        while (true)
    //        {
    //            Console.WriteLine("Enter your choice(Type 'a' for Bus, 'b' for Train) ");
    //            input = Console.ReadLine();
    //            IVehicle vehicle = null;
    //            switch (input)
    //            {
    //                case "a":
    //                    vehicle = new Bus();
    //                    break;
    //                case "b":
    //                    vehicle = new Train();
    //                    break;
    //            }
    //            totalObjects = Bus.busCount + Train.trainCount;
    //            vehicle.Travel();
    //            Console.WriteLine("Total objects created in the system ={0}", totalObjects);
    //        }
    //    }
    //}


    // Applying the NullObject pattern now
    interface IVehicle
    {
        void Travel();
    }
    class Bus : IVehicle
    {
        public static int busCount = 0;
        public Bus()
        {
            busCount++;
        }
        public void Travel()
        {
            Console.WriteLine("Let us travel with Bus");
        }
    }
    class Train : IVehicle
    {
        public static int trainCount = 0;
        public Train()
        {
            trainCount++;
        }
        public void Travel()
        {
            Console.WriteLine("Let us travel with Train");
        }
    }
    class NullVehicle : IVehicle
    {
        private static readonly NullVehicle instance = new NullVehicle();
        public static int nullVehicleCount = 0;
        public static NullVehicle Instance
        {
            get
            {
                //Console.WriteLine("We already have an instance now Use it.");
                return instance;
            }
        }
        public void Travel()
        {
            //Do Nothing
        }
    }

    class Program
    {
        static void Main(string[] vs)
        {
            Console.WriteLine("*** Null Object Pattern ***\n");
            string input = String.Empty;
            int totalObjects = 0;
            while (input != "exit")
            {
                Console.WriteLine("Enter your choice( Type 'a' for Bus, 'b' for Train.Type 'exit' to quit)");
                input = Console.ReadLine();
                IVehicle vehicle = null;
                switch (input)
                {
                    case "a":
                        vehicle = new Bus();
                        break;
                    case "b":
                        vehicle = new Train();
                        break;
                    case "exist":
                        Console.WriteLine("Closing the application");
                        vehicle = NullVehicle.Instance;
                        break;
                    default:
                        vehicle = NullVehicle.Instance;
                        if (input == "exit")
                        {
                            Console.WriteLine("Closing the application. Press Enter at end.");
                        }
                        break;
                }
                totalObjects = Bus.busCount + Train.trainCount + NullVehicle.nullVehicleCount;
                //ride the vehicle
                //if (vehicle != null)
                //    vehicle.Travel();
                //}
                Console.WriteLine("Total objects created in the system ={0}", totalObjects);
            }
            Console.ReadKey();
        }
    }
}
