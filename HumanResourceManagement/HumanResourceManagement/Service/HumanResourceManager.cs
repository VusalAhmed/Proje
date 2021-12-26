using HumanResourceManagement.InterFace;
using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Service
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] departments { get; set; }
        public int CurrentIndex { get; set; }
        public HumanResourceManager()
        {
            departments = new Department[100];
        }

        public void AddDepartment(string name, int WorkerLimit, double SalaryLimit)
        {
           if(CurrentIndex < 100)
            {
                departments[CurrentIndex] = new Department(name, WorkerLimit, SalaryLimit);
                ++CurrentIndex;
            }
        }

        public void AddEmployee(string departmentname, string fullname, string position, double salary)
        {
            throw new NotImplementedException();
        }

        public void EditDepartments(string Name, string NewName)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(string No, string FullName, double Salary, string Position)
        {
            throw new NotImplementedException();
        }

        public Department[] GetDepartments()
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(string No, string DepartmentName)
        {
            throw new NotImplementedException();
        }
    }
}
