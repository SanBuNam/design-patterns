using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.AdditionalPatterns
{/*
     Simple Factory Pattern
     : Create an object without exposing the instantiation logic to the client.
     Concept
     : In object-oriented programming, a factory is such an object that can create other objects.
       A factory can be invoked in many different ways but most often, it uses a method that can return objects with varying prototypes.
       Any subroutine that can help us to create these new objects, can be considered as a factory.
       Most importantly, it will help you to abstract the process of object creation from the consumers of the applications.
     */
    public interface IAnimalSimple
    {
        void Speak();
        void Action();
    }
    public class DogSimple : IAnimalSimple
    {
        public void Speak()
        {
            Console.WriteLine("Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Console.WriteLine("Dogs prefer barking...");
        }
    }
    public class TigerSimple : IAnimalSimple
    {
        public void Speak()
        {
            Console.WriteLine("Tiger says: Halum.");
        }
        public void Action()
        {
            Console.WriteLine("Tigers prefer hunting...");
        }
    }

    public abstract class ISimpleFactory
    {
        public abstract IAnimalSimple CreateAnimal();
    }

    public class SimpleFactory : ISimpleFactory
    {
        public override IAnimalSimple CreateAnimal()
        {
            IAnimalSimple intendedAnimal = null;
            Console.WriteLine("Enter your choice(0 for Dog, 1 for Tiger)");
            string b1 = Console.ReadLine();
            int input;
            if (int.TryParse(b1, out input))
            {
                Console.WriteLine("You have entered {0}", input);
                switch (input)
                {
                    case 0:
                        intendedAnimal = new DogSimple();
                        break;
                    case 1:
                        intendedAnimal = new TigerSimple();
                        break;
                    default:
                        Console.WriteLine("You must enter either 0 or 1");
                        //We'll throw a runtime exception for any other choices.
                        throw new ApplicationException(String.Format("Unknown Animal cannot be instantiated"));
                }
            }
            return intendedAnimal;
        }
    }

    //A client is intereted to get an animal who can speak and perform an action.
    class SimpleFactoryProgram
    {
        static void SimpleFactoryMain(string[] args)
        {
            Console.WriteLine("*** Simple Factory Pattern Demo ***\n");
            IAnimalSimple preferredType = null;
            ISimpleFactory simpleFactory = new SimpleFactory();
            #region The code region that will vary based on users preference
            preferredType = simpleFactory.CreateAnimal();
            #endregion
            #region The codes that do not change frequently
            preferredType.Speak();
            preferredType.Action();
            #endregion
            Console.ReadKey();
        }
    }
}
