﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns
{
    // Builders common interface
    interface IBuilder
    {
        void StartUpOperations();
        void BuildBody();
        void InsertWheels();
        void AddHeadlights();
        void EndOperations();
        Product GetVehicle();
    }

    // ConcreateBuilder: Car
    class Car : IBuilder
    {
        private string brandName;
        private Product product;
        public Car(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }
        public void StartUpOperations()
        {
            product.Add(string.Format("Car Model name : {0}", this.brandName));
        }
        public void BuildBody()
        {
            product.Add("This is a body of a Car");
        }
        public void InsertWheels()
        {
            product.Add("4 wheels are added");
        }
        public void AddHeadlights()
        {
            product.Add("2 Headlights are added");
        }
        public void EndOperations()
        {
        }
        public Product GetVehicle()
        {
            return product;
        }
    }

    // ConcreteBuilder: Motorcycle
    class MotorCycle: IBuilder
    {
        private string brandName;
        private Product product;
        public MotorCycle(string brand)
        {
            product = new Product();
            this.brandName = brand;
        }
        public void StartUpOperations()
        {
            product.Add(string.Format("MotorCycle Model name : {0}", this.brandName));
        }
        public void BuildBody()
        {
            product.Add("This is a body of a MotorCycle");
        }
        public void InsertWheels()
        {
            product.Add("2 wheels are added");
        }
        public void AddHeadlights()
        {
            product.Add("1 Headlight is added");
        }
        public void EndOperations()
        {
            product.Add(string.Format("Motorcycle Model Name : {0}", this.brandName));
        }
        public Product GetVehicle()
        {
            return product;
        }
    }

    // "Product"
    class Product
    {
        // We can use any data structure that you prefer e.g.List<string> etc.
        private LinkedList<string> parts;
        public Product()
        {
            parts = new LinkedList<string>();
        }
        public void Add(string part)
        {
            parts.AddLast(part);
        }
        public void Show()
        {
            Console.WriteLine("\nProduct completed as below :");
            foreach(string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    // "Director"
    class Director
    {
        IBuilder builder;
        // A series of steps-in real life, steps are complex.
        public void Construct(IBuilder builder)
        {
            this.builder = builder;
            builder.StartUpOperations();
            builder.BuildBody();
            builder.InsertWheels();
            builder.AddHeadlights();
            builder.EndOperations();
        }
    }

    class BuilderProgram
    {
        static void BuilderMain(string[] args)
        {
            Console.WriteLine("***Builder Pattern Demo***");
            Director director = new Director();

            IBuilder b1 = new Car("Ford");
            IBuilder b2 = new MotorCycle("Honda");

            // Making car
            director.Construct(b1);
            Product p1 = b1.GetVehicle();
            p1.Show();

            // Making MotorCycle
            director.Construct(b2);
            Product p2 = b2.GetVehicle();
            p2.Show();

            Console.ReadLine();
        }
    }

}
