using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.Properties
{
    public abstract class BasicCar
    {
        public string ModelName { get; set; }
        public int Price { get; set; }
        public static int SetPrice()
        {
            int price = 0;
            Random r = new Random();
            int p = r.Next(200000, 500000);
            price = p;
            return price;
        }
        public abstract BasicCar Clone();
    }

    public class Ford : BasicCar
    {
        public Ford(string m)
        {
            ModelName = m;
        }

        public override BasicCar Clone()
        {
            return (Ford)this.MemberwiseClone();
        }
    }
    public class Nano : BasicCar
    {
        public Nano(string m)
        {
            ModelName = m;
        }

        public override BasicCar Clone()
        {
            return (Nano)this.MemberwiseClone(); //shallow Clone
        }
    }

    class Program
    {
        static void PrototypeMain(string[] args)
        {
            Console.WriteLine("*** Prototype Pattern ***\n");
            // Base or Original Copy
            BasicCar nano_base = new Nano("Green Nano") { Price = 100000 };
            BasicCar ford_base = new Ford("Yellow Ford") { Price = 500000 };
            BasicCar bc1;

            // Nano
            bc1 = nano_base.Clone();
            bc1.Price = nano_base.Price + BasicCar.SetPrice();
            Console.WriteLine("Car is: {0}, and it's price is Rs. {1}", bc1.ModelName, bc1.Price);

            // Ford
            bc1 = ford_base.Clone();
            bc1.Price = ford_base.Price + BasicCar.SetPrice();
            Console.WriteLine("Car is: {0}, and it's price is Rs. {1}", bc1.ModelName, bc1.Price);

            Console.ReadLine();
        }
    }
}
