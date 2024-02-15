using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns
{
    /*
    - Chain of responsibility pattern -
    Definition:
    Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request.
    Chain the receiving objects and pass the request along the chain until an object handles it.
    Concept:
    In this pattern, you form a chain of objects where each object int he chain can handle a particular kind of request.
    If an object cannot handle the request fully, it passes the request to the next object in the chain.
     */
    public enum MessagePriority
    {
        Normal,
        High
    }
    public class Message
    {
        public string Text;
        public MessagePriority Priority;
        public Message(string msg, MessagePriority p)
        {
            Text = msg;
            this.Priority = p;
        }
    }
    public interface IReceiverCR
    {
        bool HandleMessage(Message message);
    }

    public class IssueRaiser
    {
        public IReceiverCR setFirstReceiver;
        public IssueRaiser(IReceiverCR firstReceiver)
        {
            this.setFirstReceiver = firstReceiver;
        }
        public void RaiseMessage(Message message)
        {
            if (setFirstReceiver != null)
            {
                setFirstReceiver.HandleMessage(message);
            }
        }
    }

    public class FaxErrorHandler : IReceiverCR
    {
        private IReceiverCR nextReceiver;
        public FaxErrorHandler(IReceiverCR nextReceiver)
        {
            this.nextReceiver = nextReceiver;
        }
        public bool HandleMessage(Message message)
        {
            if (message.Text.Contains("Fax"))
            {
                Console.WriteLine("");
                return true;
            }
            else
            {
                if (nextReceiver != null)
                {
                    nextReceiver.HandleMessage(message);
                }
            }
            return false;
        }
    }

    public class EmailErrorHandler : IReceiverCR
    {
        private IReceiverCR nextReceiver;
        public EmailErrorHandler(IReceiverCR nextReceiver)
        {
            this.nextReceiver = nextReceiver;
        }
        public bool HandleMessage(Message message)
        {
            if (message.Text.Contains("Email"))
            {
                Console.WriteLine("EmailErrorHandler processed {0} priority issue: {1}", message.Priority, message.Text);
                return true;
            }
            else
            {
                if (nextReceiver != null)
                {
                    nextReceiver.HandleMessage(message);
                }
            }
            return false;
        }
    }

    class ChainOfResponsibilityProgram
    {
        static void Main(string[] vs)
        {
            Console.WriteLine("\n *** Chain of Responsibility Pattern ***\n");
            /* Making the chain :
                IssuerRaiser -> FaxErrorHandler -> EmailErrorHandler
             */
            IReceiverCR faxHandler, emailHandler;

            //End of chain
            emailHandler = new EmailErrorHandler(null);

            //fax handler is placed before email handler
            faxHandler = new FaxErrorHandler(emailHandler);

            //Starting point:IssueRaiser will raise issues and set the first //handler
            IssueRaiser raiser = new IssueRaiser(faxHandler);

            Message m1 = new Message("Fax is reaching late to the destination.", MessagePriority.Normal);
            Message m2 = new Message("Emails are not raching to destinatinations.", MessagePriority.High);
            Message m3 = new Message("In Email, CC field is disabled always.", MessagePriority.Normal);
            Message m4 = new Message("Fax is not reaching destination.", MessagePriority.High);

            raiser.RaiseMessage(m1);
            raiser.RaiseMessage(m2);
            raiser.RaiseMessage(m3);
            raiser.RaiseMessage(m4);

            Console.ReadKey();
        }
    }
}
