using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.Geeks
{
    class DepthFirst
    {
        public Employee BuildEmployeeGraph()
        {
            Employee Eva = new Employee("Eva");
            Employee Sophia = new Employee("Sophia");
            Employee Brian = new Employee("Brian");
            Eva.isEmployeeOf(Sophia);
            Eva.isEmployeeOf(Brian);

            Employee Lisa = new Employee("Lisa");
            Employee Tina = new Employee("Tina");
            Employee John = new Employee("John");
            Employee Mike = new Employee("Mike");
            Sophia.isEmployeeOf(Lisa);
            Sophia.isEmployeeOf(John);
            Brian.isEmployeeOf(Tina);
            Brian.isEmployeeOf(Mike);

            return Eva;

        }

        public Employee Search(Employee root, string nameToSearchFor)
        {
            if (nameToSearchFor == root.name)
                return root;

            Employee personFound = null;
            for (int i = 0; i < root.Employees.Count; i++)
            {
                personFound = Search(root.Employees[i], nameToSearchFor);
                if (personFound != null)
                    break;
            }
            return personFound;
        }

        public void Traverse(Employee root)
        {
            Console.WriteLine(root.name);
            for (int i = 0; i < root.Employees.Count; i++)
            {
                Traverse(root.Employees[i]);
            }
        }

    }

    public class Employee
    {
        public string name { get; set; }
        public Employee(string _name)
        {
            this.name = _name;
        }

        public List<Employee> Employees
        {
            get
            {
                return EmployeesList;
            }
        }

        readonly List<Employee> EmployeesList = new List<Employee>();

        public void isEmployeeOf(Employee e)
        {
            EmployeesList.Add(e);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
