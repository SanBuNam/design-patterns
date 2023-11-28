using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns
{
    // R.L. exp.
    // In a restaurant, based on customer inputs, a chef varies the taste of dishes to make the final products.
    public interface IAnimal
    {
        void Speak();
        void Action();
    }
    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Console.WriteLine("Dogs prefer barking...\n");
        }
    }
    public class Tiger : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Tiger syas : Halum.");
        }
        public void Action()
        {
            Console.WriteLine("Tigers prefer hunting...\n");
        }
    }
    public abstract class IAnimalFactory
    {
        //Remember the GoF definition which says "....Factory method lets a class
        //defer instantiation to subclasses." Following method will create a Tiger
        //or Dog But at this point it does not know whether it will get a Dog or a
        //Tiger. It will be decided by the subclasses i.e.DogFactory or TigerFactory.
        //So, the following method is acting like a factory (of creation).

        public IAnimal MakeAnimal()
        {
            Console.WriteLine("\n IAnimalFactory.MakeAnimal()-You cannot ignore parent rules.");
            /* At this point, it doens't know whether it will get a Dog or a Tiger.
               It will be decided by the subclasses i.e.DogFactory or TigerFactory.
               But it knows that it will speak and it will have a preferred way of Action.*/
            IAnimal animal = CreateAnimal();
            animal.Speak();
            animal.Action();
            return animal;
        }
        // So, the following method is acting like a factory (of creation).
        public abstract IAnimal CreateAnimal();
    }
    public class DogFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Dog();
        }
    }
    public class TigerFactory : IAnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Tiger();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Factory pattern demo***\n");
            // Creating a Tiger Factory
            IAnimalFactory tigerFactory = new TigerFactory();
            IAnimal aTiger = tigerFactory.MakeAnimal();

            // Creating a tiger using the Factory Method
            //IAnimal aTiger = tigerFactory.CreateAnimal();
            //aTiger.Speak();
            //aTiger.Action();

            // Creating a DogFactory
            IAnimalFactory dogFactory = new DogFactory();
            IAnimal aDog = dogFactory.MakeAnimal();

            // Creating a dog using the Factory Method
            //IAnimal aDog = dogFactory.CreateAnimal();
            //aDog.Speak();
            //aDog.Action();

            Console.ReadKey();
        }
    }
}
