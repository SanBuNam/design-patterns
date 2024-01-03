using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.BehavioralPatterns
{
    interface IEmployee
    {
        void PrintStructure();
        void Accept(IVisitor visitor);
    }
    // Employees who have Subordinates
    class CompositeEmployee : IEmployee
    {
        private string name;
        private string dept;
        private int yearsOfExperience;
        private List<IEmployee> controls;
        public CompositeEmployee(string name, string dept, int experience)
        {
            this.name = name;
            this.dept = dept;
            this.yearsOfExperience = experience;
            controls = new List<IEmployee>();
        }
        public void Add(IEmployee e)
        {
            controls.Add(e);
        }
        public void Remove(IEmployee e)
        {
            controls.Add(e);
        }
        public string Name
        {
            get { return this.name; }
            //set {_name = value;}
        }
        public string Dept
        {
            get { return this.dept; }
        }
        public int Experience
        {
            get { return this.yearsOfExperience; }
        }
        public List<IEmployee> Controls
        {
            get { return this.controls; }
        }
        public void PrintStructure()
        {
            Console.WriteLine("\t" + this.name + "works in" + this.dept + "Experience :" + this.yearsOfExperience + "years");
            foreach(IEmployee e in controls)
            {
                e.PrintStructure();
            }
        }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompositeElement(this);
        }
    }

    class Employee : IEmployee
    {
        private string name;
        private string dept;
        private int yearsOfExperience;
        public Employee(string name, string dept, int experience)
        {
            this.name = name;
            this.dept = dept;
            this.yearsOfExperience = experience;
        }
        public void PrintStructure()
        {
            Console.WriteLine("\t\t" + this.name + "works in" + this.dept + "Experience :" + this.yearsOfExperience + "years");
        }
        public string Name
        {
            get { return this.name; }
        }
        public string Dept
        {
            get { return this.dept; }
        }
        public int Experience
        {
            get { return this.yearsOfExperience; }
        }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitLeafNode(this);
        }
    }

    interface IVisitor
    {
        void VisitCompositeElement(CompositeEmployee employee);
        void VisitLeafNode(Employee employee);
    }
    class Visitor : IVisitor
    {
        public void VisitCompositeElement(CompositeEmployee employee)
        {
            bool eligibleForPromotion = employee.Experience > 15 ? true : false;
            Console.WriteLine("\t\t" + employee.Name + "from" + employee.Dept + "is eligible for promotion?" + eligibleForPromotion);
        }
        public void VisitLeafNode(Employee employee)
        {
            bool eligibleForPromotion = employee.Experience > 12 ? true : false;
            Console.WriteLine("\t\t" + employee.Name + "from" + employee.Dept + "is eligible for promotion?" + eligibleForPromotion);
        }
    }

    class VisitorProgram
    {
        static void VisitorMain(string[] args)
        {
            Console.WriteLine("***Visitor Pattern combined with Composite Patter Demo***\n");
            CompositeEmployee Principal = new CompositeEmployee("Dr.S.Som(Principal)", "Planning-Supervising-Managing", 20);
            CompositeEmployee hodMaths = new CompositeEmployee("Mrs.S.Das(HOD-Maths)", "Maths", 14);
            CompositeEmployee hodCompSc = new CompositeEmployee("Mrs.V.Sarcar(HOD-CSE)", "Computer Sc.", 16);
            Employee mathTeacher1 = new Employee("Math Teacher-1", "Maths", 14);
            Employee mathTeacher2 = new Employee("Math Teacher-2", "Maths", 6);
            Employee cseTeacher1 = new Employee("CSE Teacher-1", "Computer Sc.", 10);
            Employee cseTeacher2 = new Employee("CSE Teacher-2", "Computer Sc.", 13);
            Employee cseTeacher3 = new Employee("CSE Teacher-3", "Computer Sc.", 7);
            hodMaths.Add(mathTeacher1);
            hodMaths.Add(mathTeacher2);
            hodCompSc.Add(cseTeacher1);
            hodCompSc.Add(cseTeacher2);
            hodCompSc.Add(cseTeacher3);
            Principal.Add(hodMaths);
            Principal.Add(hodCompSc);
            Console.WriteLine("\n Testing the overall structure");
            Principal.PrintStructure();
            Console.WriteLine("\n***Visitor starts visiting our composite structure***\n");
            IVisitor aVisitor = new Visitor();
            foreach (IEmployee e in Principal.Controls)
            {
                e.Accept(aVisitor);
            }
            foreach (IEmployee e in hodMaths.Controls)
            {
                e.Accept(aVisitor);
            }
            foreach (IEmployee e in hodCompSc.Controls)
            {
                e.Accept(aVisitor);
            }
            Console.ReadLine();
        }
    }
}
