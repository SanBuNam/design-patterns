using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns
{
    interface IObserver
    {
        void Update(int i);
    }
    class ObserverType1 : IObserver
    {
        string nameOfObserver;
        public ObserverType1(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(int i)
        {
            Console.WriteLine("{0} has received an alert: Someone has updated myValue in Subject to: {1}", nameOfObserver, i);
        }
    }
    class ObserverType2 : IObserver
    {
        string nameOfObserver;
        public ObserverType2(String name)
        {
            this.nameOfObserver = name;
        }
        public void Update(int i)
        {
            Console.WriteLine("{0} notified: myValue in Subject at present: {1}", nameOfObserver, i);
        }
    }
    interface ISubject
    {
        void Register(IObserver o);
        void Unregister(IObserver o);
        void NotifyRegisteredUsers(int i);
    }
    class Subject:ISubject
    {
        List<IObserver> observerList = new List<IObserver>();
        private int flag;
        public int Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
                //Flag value changed. So notify observer/s.
                NotifyRegisteredUsers(flag);
            }
        }
        public void Register(IObserver anObserver)
        {
            observerList.Add(anObserver);
        }
        public void Unregister(IObserver anObserver)
        {
            observerList.Remove(anObserver);
        }
        public void NotifyRegisteredUsers(int i)
        {
            foreach (IObserver observer in observerList)
            {
                observer.Update(i);
            }
        }
    }
    
    class ObserverProgram
    {
        static void ObserverMain(string[] args)
        {
            Console.WriteLine("***Observer Pattern Demo***\n");
            
            //From 3 observers, 2 of them are ObserverType1, 1 of them is ObserverType2
            IObserver myObserver1 = new ObserverType1("Roy");
            IObserver myObserver2 = new ObserverType1("Kevin");
            IObserver myObserver3 = new ObserverType2("Bose");

            //Registering the observer
            Subject subject = new Subject();
            subject.Register(myObserver1);
            subject.Register(myObserver2);
            subject.Register(myObserver3);
            subject.Flag = 5;

            subject.Unregister(myObserver1);
            subject.Flag = 50;

            subject.Register(myObserver1);
            subject.Flag = 50;
            Console.ReadKey();
        }
    }
}
