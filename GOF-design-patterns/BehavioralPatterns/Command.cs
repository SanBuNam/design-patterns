using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns
{
    public interface ICommand
    {
        void Do();
        void UnDo();
    }

    public class AdditionalCommand : ICommand
    {
        private IReceiver receiver;
        public AdditionalCommand(IReceiver recv)
        {
            receiver = recv;
        }
        public void Do()
        {
            receiver.OptionalTasksPriorProcessing();
            receiver.Add2WithNumber();
            receiver.OptionalTasksPostProcessing();
        }
        public void UnDo()
        {
            Console.WriteLine("Trying undoing addition...");
            receiver.Remove2FromNumber();
            Console.WriteLine("Undo request processed.");
        }
    }

    public interface IReceiver
    {
        void Add2WithNumber();
        void Remove2FromNumber();
        void OptionalTasksPriorProcessing();
        void OptionalTasksPostProcessing();
    }

    public class Receiver1 : IReceiver
    {
        int myNumber;
        public int MyNumber
        {
            get
            {
                return myNumber;
            }
            set
            {
                myNumber = value;
            }
        }
        public Receiver1()
        {
            myNumber = 10;
            Console.WriteLine("Receiver1 initialized with {0}", myNumber);
            Console.WriteLine("The objects of receiver1 cannot set beyond {0}", myNumber);
        }
        public void OptionalTasksPriorProcessing()
        {
            Console.WriteLine("Receiver1.OptionalTasksPriorProcessing");
        }
        public void OptionalTasksPostProcessing()
        {
            Console.WriteLine("Receiver1.OptionalTasksPostProcessing\n");
        }
        public void Add2WithNumber()
        {
            int presentNumber = this.MyNumber;
            this.MyNumber = this.MyNumber + 2;
            Console.WriteLine("{0}+2={1}", presentNumber, this.MyNumber);
        }
        public void Remove2FromNumber()
        {
            int presentNumber = this.MyNumber;
            if (presentNumber > 10)
            {
                this.MyNumber = this.MyNumber - 2;
                Console.WriteLine("{0}-2={1}", presentNumber, this.MyNumber);
            }
            else
            {
                Console.WriteLine("Nothing more to undo...");
            }
        }
    }

    public class Receiver2 : IReceiver
    {
        int myNumber;
        public int MyNumber
        {
            get
            {
                return myNumber;
            }
            set
            {
                myNumber = value;
            }
        }
        public Receiver2()
        {
            myNumber = 75;
            Console.WriteLine("Receiver2 initialized with {0}", myNumber);
            Console.WriteLine("The objects of receiver2 cannot set beyond {0}", myNumber);
        }
        public void OptionalTasksPriorProcessing()
        {
            Console.WriteLine("Receiver2.OptionalTaskPriorProcessing");
        }
        public void OptionalTasksPostProcessing()
        {
            Console.WriteLine("Receiver2.OptionalTaskPostProcessing");
        }
        public void Add2WithNumber()
        {
            int presentNumber = this.MyNumber;
            this.MyNumber = this.MyNumber + 2;
            Console.WriteLine("{0}+2={1}", presentNumber, this.MyNumber);
        }
        public void Remove2FromNumber()
        {
            int presentNumber = this.MyNumber;
            if (presentNumber > 75)
            {
                this.MyNumber = this.MyNumber - 2;
                Console.WriteLine("{0}-2={1}", presentNumber, this.MyNumber);
            }
            else
            {
                Console.WriteLine("Nothing more to undo...");
            }
        }
    }

    public class Invoker
    {
        ICommand commandToBePerformed;
        public void SetCommand(ICommand command)
        {
            this.commandToBePerformed = command;
        }
        public void ExecuteCommand()
        {
            commandToBePerformed.Do();
        }
        public void UndoCommand()
        {
            commandToBePerformed.UnDo();
        }
    }

    class CommandClientProgram
    {
        static void CommandClientMain(string[] args)
        {
            Console.WriteLine("***Command Pattern Q&As***");
            Console.WriteLine("***A simple demo with undo supported operations * **\n");

            Invoker invoker = new Invoker();
            IReceiver intendedreceiver = new Receiver1();
            ICommand currentCmd = new AdditionalCommand(intendedreceiver);
            
            invoker.SetCommand(currentCmd);
            invoker.ExecuteCommand();
            invoker.ExecuteCommand();
            invoker.UndoCommand();
            invoker.UndoCommand();
            invoker.UndoCommand();

            Console.WriteLine("\nTesting receiver-Receiver2");
            intendedreceiver = new Receiver2();
            currentCmd = new AdditionalCommand(intendedreceiver);
            invoker.SetCommand(currentCmd);
            invoker.ExecuteCommand();
            invoker.UndoCommand();
            invoker.UndoCommand();
            Console.ReadKey();
        }
    }
}
