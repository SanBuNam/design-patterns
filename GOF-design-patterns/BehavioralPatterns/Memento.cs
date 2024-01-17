using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns
{
    /* Memento pattern
       Definition : Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.
       Concept : The dictionary defintion of the word memento is that it's a reminder of past events. When using this pattern, you can restore an object to its previous state.
                 This pattern provides an object-oriented way to save the state of an object.
     */
    class Memento
    {
        private string state;
        //If we want the state to be same when a memento is created for the first time, we could prefer a constructor (as shown below)
        //instead of using a setter method in this case.
        //public Memento(string state)
        //{
        //    this.state = state;
        //}
        public string State
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
    }
    /*  
     Originator class
     Make an object (originator) itself responsible for:
    1. Saving its internal state to a (memento) object.
    2. Restoring to a previous state from a (memento) object.
       Only the originator that created a memento is allowed to acess it.
     */
    class Originator
    {
        private string state;
        Memento myMemento;
        //public Originator()
        //{
        //    this.state = "Initial state";
        //}
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                Console.Write("Current State : {0}", state);
            }
        }
        // Originator will supply the memento in respond to caretaker's request
        public Memento GetTheMemento()
        {
            // Creating a memento with the current state
            myMemento = new Memento();
            myMemento.State = state;
            return myMemento;
        }
        // Back to old state (Restore)
        public void RevertToState(Memento previousMemento)
        {
            Console.WriteLine("Restoring to previous state...");
            this.state = previousMemento.State;
            Console.WriteLine("Current State : {0}", state);
        }
    }

    /*
     The 'Caretaker' class.
    A client (caretaker) can request a memento from the originator
    to save the internal state of the originator and pass a memento back to the originator (to restore to a previous state)
    This enables to save and restore the internal state of an originator without violating its encapsulation.
     */
    class MementoProgram
    {
        static void MementoMain(string[] args)
        {
            Console.WriteLine("***Memento Pattern QAs***");
            Console.WriteLine("***Demonstration-Caretaker is using multiple restore points * **\n");
            //Originator is initialized with a state
            Originator originatorObject = new Originator();
            Memento mementoObject;
            IList<Memento> savedStates = new List<Memento>();
            Console.WriteLine("A new set of verification");
            //State-1
            originatorObject.State = "State-1";
            savedStates.Add(originatorObject.GetTheMemento());
            //State-2
            originatorObject.State = "State-2";
            savedStates.Add(originatorObject.GetTheMemento());
            //State-3
            originatorObject.State = "State-3";
            savedStates.Add(originatorObject.GetTheMemento());
            //State-4 which is not saved
            originatorObject.State = "State-4";

            //Available restore points
            Console.WriteLine("Currently available restore points are :");
            foreach (Memento m in savedStates)
            {
                Console.WriteLine(m.State);
            }

            //Roll back starts...
            Console.WriteLine("Started restoring process...");
            for (int i = savedStates.Count; i > 0; i--)
            {
                mementoObject = originatorObject.GetTheMemento();
                mementoObject.State = savedStates[i - 1].State;
                originatorObject.RevertToState(mementoObject);
            }
        }
    }
}
