using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns
{
    public interface IState
    {
        void MoveState();
    }

    public class OnState : IState
    {
        public void MoveState()
        {
            Console.WriteLine("On State");
        }
    }

    public class OffState : IState
    {
        public void MoveState()
        {
            Console.WriteLine("Off State");
        }
    }

    public abstract class ElectronicGoods
    {
        protected IState state;
        //public ElectronicGoods(IState state)
        //{
        //    this.state = state;
        //}
        public IState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        abstract public void MoveToCurrentState();
    }

    public class Television : ElectronicGoods
    {
        //public Television(IState state) : base(state)
        //{
        //}
        public override void MoveToCurrentState()
        {
            Console.WriteLine("\n Television is function at : ");
            state.MoveState();
        }

    }

    public class VCD : ElectronicGoods
    {
        //public VCD(IState state) : base(state)
        //{
        //}
        public override void MoveToCurrentState()
        {
            Console.WriteLine("\n VCD is functioning at : ");
            state.MoveState();
        }
    }

    class BridgeProgram
    {
        static void BridgeMain(string[] args)
        {
            Console.WriteLine("***Bridge Pattern Demo***");
            Console.WriteLine("\nDealing with a Television:");
            IState presentState = new OnState();
            // ElectronicGoods eItem = new Television(presentState);
            ElectronicGoods eItem = new Television();
            eItem.State = presentState;
            eItem.MoveToCurrentState();

            presentState = new OffState();
            // eItem = new Television(presentState);
            eItem.State = presentState;
            eItem.MoveToCurrentState();
            Console.WriteLine("\n \n Dealing with a VCD:");

            presentState = new OnState();
            // eItem = new VCD(presentState);
            eItem = new VCD();
            eItem.State = presentState;
            eItem.MoveToCurrentState();

            presentState = new OffState();
            // eItem = new VCD(presentState);
            eItem.State = presentState;
            eItem.MoveToCurrentState();
            Console.ReadLine();
        }
    }
}
