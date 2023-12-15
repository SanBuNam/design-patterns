using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOF_design_patterns.StructuralPatterns
{
    interface IEmployee
    {
        void PrintStructures();
    }
    class CompositeEmployee : IEmployee
    {
        private string name;
        private string dept;
        private List<IEmployee> controls;
        public CompositeEmployee(string name, string dept)
        {
            this.name = name;
            this.dept = dept;
            controls = new List<IEmployee>();
        }
        public void Add(IEmployee e)
        {
            controls.Add(e);
        }
        public void Remove(IEmployee e)
        {
            controls.Remove(e);
        }
        public void PrintStructures()
        {
            Console.WriteLine("\t" + this.name + "works in" + this.dept);
            foreach(IEmployee e in controls)
            {
                e.PrintStructures();
            }
        }
    }
    
    class Employee : IEmployee
    {
        private string name;
        private string dept;
        public Employee(string name, string dept)
        {
            this.name = name;
            this.dept = dept;
        }
        public void PrintStructures()
        {
            Console.WriteLine("\t\t" + this.name + "works in" + this.dept);
        }
    }

    class CompositionProgram
    {
        static void CompositionMain(string[] args)
        {
            CompositeEmployee Principal = new CompositeEmployee("Dr.S.Som(Principal)", "Planning-Supervising-Managing");
            CompositeEmployee hodMaths = new CompositeEmployee("Mrs.S.Das(HOD-Maths)", "Maths");
            CompositeEmployee hodCompSc = new CompositeEmployee("Mr. V.Sarcar(HOD-CSE)", "Computer Sc.");

            Employee mathTeacher1 = new Employee("Math Teacher-1", "Maths");
            Employee mathTeacher2 = new Employee("Math Teacher-2", "Maths");

            Employee cseTeacher1 = new Employee("CSE Teacher-1", "Computer Sc.");
            Employee cseTeacher2 = new Employee("CSE Teacher-2", "Computer Sc.");
            Employee cseTeacher3 = new Employee("CSE Teacher-3", "Computer Sc.");

            hodMaths.Add(mathTeacher1);
            hodMaths.Add(mathTeacher2);

            hodCompSc.Add(cseTeacher1);
            hodCompSc.Add(cseTeacher2);
            hodCompSc.Add(cseTeacher3);

            Principal.Add(hodMaths);
            Principal.Add(hodCompSc);
            Principal.PrintStructures();

            hodCompSc.PrintStructures();

            mathTeacher1.PrintStructures();

            hodCompSc.Remove(cseTeacher2);
            Principal.PrintStructures();

            Console.ReadKey();
        }
    }
}
