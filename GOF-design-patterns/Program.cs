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
    // State Pattern
    // Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.
    /*
     The functionalities of a traffic signal or a television can also be considered to be
    an example of the State pattern. For example, you can change the channel if the TV is
    already in switched-on mode. It will not respond to the channel change requests if it is in
    switched-off mode.
     */
    interface IPossibleStates
    {
        void PressOnButton(TV context);
        void PressOffButton(TV context);
        void PressMuteButton(TV context);
    }

    class Off : IPossibleStates
    {
        TV tvContext;
        //Initially we'll start from Off state
        public Off(TV context)
        {
            Console.WriteLine(" TV is Off now.");
            this.tvContext = context;
        }
        //Users can press any of these buttons at this state-On, Off or Mute
        //TV is Off now, user is pressing On button
        public void PressOnButton(TV context)
        {
            Console.WriteLine("You pressed On button. Going from Off to On state");
            tvContext.CurrentState = new On(context);
        }
        //TV is Off already, user is pressing Off button again 
        public void PressOffButton(TV context)
        {
            Console.WriteLine("You pressed Off button. TV is already in Off state");
        }
        //TV is Off now, user is pressing Mute button
        public void PressMuteButton(TV context)
        {
            Console.WriteLine("You pressed Mute button. TV is already in Off state, so Mute operation will not work.");
        }
    }

    class On : IPossibleStates
    {
        TV tvContext;
        public On(TV context)
        {
            Console.WriteLine("TV is On now.");
            this.tvContext = context;
        }
        //Users can press any of these buttons at this state-On, Off or Mute
        //TV is On already, user is pressing On button again
        public void PressOnButton(TV context)
        {
            Console.WriteLine("You pressed On button. TV is already in On state.");
        }
        //TV is On now, user is pressing Off button
        public void PressOffButton(TV context) 
        {
            Console.WriteLine("You pressed Off button. Going from On to Off state.");
            tvContext.CurrentState = new Off(context);
        }
        //TV is On now, user is prsesing Mute button
        public void PressMuteButton(TV context)
        {
            Console.WriteLine("You pressed Mute button. Going from On to Mute mode.");
            tvContext.CurrentState = new Mute(context);
        }
    }

    class Mute : IPossibleStates
    {
        TV tvContext;
        public Mute(TV context)
        {
            Console.WriteLine("TV is in Mute mode now.");
            this.tvContext = context;
        }
        //Users can press any of these buttons at this state-On, Off or Mute
        //TV is in mute, user is pressing On button
        public void PressOnButton(TV context)
        {
            Console.WriteLine("You pressed On button.Going from Mute mode to On state.");
            tvContext.CurrentState = new On(context);
        }
        //TV is in mute, user is pressing Off button
        public void PressOffButton(TV context)
        {
            Console.WriteLine("You pressed Off button.Going to Mute mode to Off state.");
            tvContext.CurrentState = new Off(context);
        }
        //TV is in mute already, user is pressing mute button again
        public void PressMuteButton(TV context)
        {
            Console.WriteLine("You pressed Mute button. TV is already in Mute mode.");
        }
    }

    class TV
    {
        private IPossibleStates currentState;
        public IPossibleStates CurrentState
        {
            //get;set;//Now working as expected
            get
            {
                return currentState;
            }
            // Usually this value will be set by the class that implements the interface "IPossibleStates
            set
            {
                currentState = value;
            }
        }
        public TV()
        {
            this.currentState = new Off(this);
        }
        public void PressOffButton()
        {
            currentState.PressOffButton(this); //Delegating the state
        }
        public void PressOnButton()
        {
            currentState.PressOnButton(this);//Delegating the state
        }
        public void PressMuteButton()
        {
            currentState.PressMuteButton(this);//Delegating the state
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***State Pattern Demo***\n");
            //Initially TV is Off
            TV tv = new TV();
            Console.WriteLine("User is pressing buttons in the following sequence: ");
            Console.WriteLine("Off->Mute->On->On->Mute->Mute->Off\n");
            //TV is already in Off state
            tv.PressOffButton();
            //TV is already in Off state, still pressing the Mute button
            tv.PressMuteButton();
            //Making the TV on
            tv.PressOnButton();
            //TV is already in On state, pressing On button again
            tv.PressOnButton();
            //Putting the TV in Mute mode
            tv.PressMuteButton();
            //TV is already in Mute, pressing Mute button again
            tv.PressMuteButton();
            //Making the TV off
            tv.PressOffButton();
            // Wait for user
            Console.Read();
        }
    }
}
