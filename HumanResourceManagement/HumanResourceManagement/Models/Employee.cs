using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Employee
    {
        private static int Count = 1000;
        public string No { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartmentName { get; set; }
        

        public Employee(string fullname, string position, double salary, string departmentname)
        {
         
            FullName = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname;

            string Naming = departmentname.ToUpper().Substring(0, 2);
            Count++;
            No = No + Naming + Count;
           
         }

        

        public override string ToString()
        {
            return $"{FullName} {Position} {Salary} {DepartmentName} {No}";

        }

    }
}
