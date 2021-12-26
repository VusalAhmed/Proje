using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public Employee[] Employees { get; set; }
        public int CurrentIndex { get; set; }



        public Department(string name, int workerlimit, double salarylimit)
        {
            // if (Employees.Length <= 0)
            // {
            //    Console.WriteLine("isci sayi minumum 1 ola biler");
            //    return;
            // }
            // if (SalaryLimit < 250)
            // {
            //     Console.WriteLine("maas 250 aznin uzerinde olmalidir");
            //    return;
            //  }
            // if (Name.Length < 2)
            //  {
            //    Console.WriteLine("Departmentin adi 2 herfden az ola bilmez");
            //    return;
            // }


            Employees = new Employee[workerlimit];
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;

        }
        public double CalcSalaryAverage()
        {
            if (CurrentIndex == 0)
                return 0;
            double totalSalary = 0;
            int count = 0;
            foreach (Employee item in Employees)
            {
                if (item != null)
                {
                    totalSalary += item.Salary;
                    count++;

                }
                else
                {
                    break;
                }





            }
            return totalSalary / count;



        }

        public void AddEmployee(Employee emp1)
        {
            if(CurrentIndex < WorkerLimit)
            {
                Employees[CurrentIndex] = emp1;
                ++CurrentIndex;
                Console.WriteLine("Isci ugurla elave olundu");

            }
            else { Console.WriteLine("Isci limiti dolub ve buna gorede isci elave olunmadi"); }
        }
        public int GetEmployeeCount()
        {
            int count = 0;
            foreach (var item in Employees)
            {
                if (item != null) ++count;
                else break;
            }
            return count;
        }
    }
}
