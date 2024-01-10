using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GOF_design_patterns.BehavioralPatterns.TemplateMethod;


namespace GOF_design_patterns
{
    public interface ICommand
    {
        void Do();
    }
    public class MyUndoCommand : ICommand
    {
        private Receiver receiver;
        public MyUndoCommand(Receiver recv)
        {
            receiver = recv;
        }
        public void Do()
        {
            // Perform any optional task prior to Undo
            receiver.OptionalTaskPriorToUndo();
            // Call Undo in receiver now
            receiver.PerformUndo();
        }
    }
    public class MyRedoCommand : ICommand
    {
        private Receiver receiver;
        public MyRedoCommand(Receiver recv)
        {
            receiver = recv;
        }
        public void Do()
        {
            // Perform any optional task prior to ReDo
            receiver.OptionalTaskPriorToRedo();
            // Call ReDo in receiver now
            receiver.PerformRedo();
        }
    }
    // Receiver Class
    public class Receiver
    {
        public void PerformUndo()
        {
            Console.WriteLine("Executing-MyUndoCommand");
        }
        public void PerformRedo()
        {
            Console.WriteLine("Executing-MyRedoCommand");
        }
        //Optional method-If you want to perform any prior tasks before Undo.
        public void OptionalTaskPriorToUndo()
        {
            Console.WriteLine("Executing-Optional Tasks prior to execute undo command");
        }
        //Optional method-If you want to peform my prior tasks before Redo.
        public void OptionalTaskPriorToRedo()
        {
            Console.WriteLine("Executing-Optional Tasks prior to execute redo command");
        }
    }
    // Invoker class
    public class Invoke
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
    }
    class CommandClientProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Command Pattern Demo***\n");
            /*Client holds both the Invoker and Command Objects*/
            Invoke invoker = new Invoke();
            Receiver intendedreceiver = new Receiver();

            MyUndoCommand undoCmd = new MyUndoCommand(intendedreceiver);
            invoker.SetCommand(undoCmd);
            invoker.ExecuteCommand();

            MyRedoCommand redoCmd = new MyRedoCommand(intendedreceiver);
            invoker.SetCommand(redoCmd);
            invoker.ExecuteCommand();
            Console.ReadKey();
        }
    }
}
