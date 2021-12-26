using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.InterFace
{
    interface IHumanResourceManager
    {
        
        Department [] departments { get; }
        void AddDepartment( string name, int WorkerLimit, double SalaryLimit);
        Department[] GetDepartments();
        void EditDepartments(string Name, string NewName);
        void AddEmployee(string departmentname, string fullname, string position, double salary);
        void RemoveEmployee(string No, string DepartmentName);
        void EditEmployee(string No, string FullName, double Salary, string Position);
        

    }
}
