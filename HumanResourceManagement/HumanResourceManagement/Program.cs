using HumanResourceManagement.Models;
using HumanResourceManagement.Service;
using System;

namespace HumanResourceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            //Employee worker1 = new Employee("Vusal Ahmadzada", "Director", 20000, "DR");
            //Employee worker2 = new Employee("Malik Gurbanli", "Developer", 10000, "IT");
            //Employee worker3 = new Employee("Ismayil Gurbanli", "Designer", 7500, "DR");
            //Employee worker4 = new Employee("Osmanli Rasul", "Cyber Security", 12500, "CS");

            //Employee[] Employees = { worker1, worker2, worker3, worker4 };
            //Department department1 = new Department("Meta", 8000, 1200);
            //department1.Employees = Employees;
            //humanResourceManager.departments[0] = department1;
           humanResourceManager.AddDepartment("Meta", 80, 5000);
            do
            {
                Console.WriteLine("---------------------HumanResourceManager---------------------");
                Console.WriteLine("Etmek istediyiniz emeliyyatin reqemini daxil ediniz:");
                Console.WriteLine("1 - Departmentlerin siyahisini gostermek");
                Console.WriteLine("2 - Department yaratmaq");
                Console.WriteLine("3 - Departmentde deyisiklik etmek");
                Console.WriteLine("4 - Iscilerin siyahisini gostermek");
                Console.WriteLine("5 - Departmentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("6 - Isci elave etmek");
                Console.WriteLine("7 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("8 - Departmentden isci silmek");
                string choose = Console.ReadLine();
                double chooseNum;
                double.TryParse(choose, out chooseNum);

                switch (chooseNum)
                {
                    case 1:
                        PrintDepartment(humanResourceManager);
                        Console.ReadLine();
                        Console.Clear();

                        break;
                    case 2:
                       AddDepartment( humanResourceManager);
                        Console.ReadLine();
                       Console.Clear();
                      break;
                    case 3:
                        UpdateDepartment( humanResourceManager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        PrintAllEmployees(humanResourceManager);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 5:
                        PrintOneDepartmentEmployees(humanResourceManager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        AddEmployee( humanResourceManager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        UpdateEmployee(humanResourceManager);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun daxil ediniz");
                        break;

                }


            }
            while (true);



        }

        static void PrintDepartment( HumanResourceManager humanResourceManager)
        {
            foreach (var D in humanResourceManager.departments)
            {
                if ( D == null)
                    break;
                Console.WriteLine(" Department Name = "+D.Name);
                Console.WriteLine(" Department hal hazirki isci sayi = "+D.GetEmployeeCount());
                Console.WriteLine(" Department isci ortalama maasi = "+D.CalcSalaryAverage());
                Console.WriteLine(" Department isci limiti  = "+D.WorkerLimit);
                Console.WriteLine(" Department maas limiti = "+D.SalaryLimit);
                Console.WriteLine();
            }
        }
        static void AddDepartment(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Departmentin adini daxil ediniz");
            string name = Console.ReadLine();
            Console.WriteLine("Isci sayini daxil ediniz");
            string WorkerLimit = Console.ReadLine();
            int WorkerLimitNum = 0;
            while (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum <= 0)
            {
                Console.WriteLine("Duzgun daxil ediniz");
                WorkerLimit = Console.ReadLine();
            }
            Console.WriteLine("SalaryLimiti daxil ediniz(Min 250 olmalidir)");
            string salaryLimit = Console.ReadLine();
            double salaryLimitNum = 0;
            while (!double.TryParse(salaryLimit, out salaryLimitNum) || salaryLimitNum <= 249)
            {
                Console.WriteLine("Duzgun daxil ediniz(Min 250 olmalidir)");
                salaryLimit = Console.ReadLine();
            }
            humanResourceManager.AddDepartment(name, WorkerLimitNum, salaryLimitNum);
            Console.WriteLine("Department ugurla elave olundu");
        }
        static void UpdateDepartment(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Deyisiklikler aparmaq istediyiniz department adini daxil edin:");
            string name = Console.ReadLine();
            Department dep = null;
            foreach (var D in humanResourceManager.departments)
            {
                if (D == null)
                    break;
                else if (D.Name == name)
                {
                    dep = D;
                    break;
                }
            }
            if (dep == null)
            {
                Console.WriteLine("Duzgun daxil etmediniz");
                return;
            }
            Console.WriteLine("Indiki department adi = " + dep.Name);
            Console.WriteLine("Indiki isci limiti = " + dep.WorkerLimit);
            Console.WriteLine("Indiki maas limiti = " + dep.SalaryLimit);

            Console.WriteLine("Departmentin adini daxil ediniz");
            name = Console.ReadLine();

            Console.WriteLine("Isci sayini daxil ediniz minimum " + (dep.GetEmployeeCount() + 1));
            string WorkerLimit = Console.ReadLine();
            int WorkerLimitNum = 0;
            while (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum <= dep.GetEmployeeCount())
            {
                Console.WriteLine("Duzgun daxil ediniz minimum " + (dep.GetEmployeeCount() + 1));
                WorkerLimit = Console.ReadLine();
            }
            Console.WriteLine("SalaryLimiti daxil ediniz minimum " + (dep.SalaryLimit +1));
            string salaryLimit = Console.ReadLine();
            double salaryLimitNum = 0;
            while (!double.TryParse(salaryLimit, out salaryLimitNum) || salaryLimitNum <= dep.SalaryLimit)
            {
                Console.WriteLine("Duzgun daxil ediniz minimum " + (dep.SalaryLimit +1));
                salaryLimit = Console.ReadLine();

            }
            dep.Name = name;
            dep.WorkerLimit = WorkerLimitNum;
            dep.SalaryLimit = salaryLimitNum;
            Console.WriteLine("Departmentiniz ugurla yenilendi");
        }
        static void PrintOneDepartmentEmployees(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Iscilerini gormek istediyiniz department adini daxil edin");
            string name = Console.ReadLine();
            Department dep = null;
            foreach (var D in humanResourceManager.departments)
            {
                if (D == null)
                    break;
                else if (D.Name == name)
                {
                    dep = D;
                    break;
                }
            }
            if (dep == null)
            {
                Console.WriteLine("Duzgun daxil etmediniz");
                return;
            }
            foreach (var E in dep.Employees)
            {
                if (E == null) break;
                Console.WriteLine(E);

            }
        }
        static void PrintAllEmployees(HumanResourceManager humanResourceManager)
        {
            foreach (var D in humanResourceManager.departments )
            {
                if (D == null)
                    break;
                Console.WriteLine(D.Name + " Departmentdeki isciler");
                foreach (var E in D.Employees)
                {
                    if (E == null)
                        break;
                    Console.WriteLine(E);
                }
                Console.WriteLine();
            }    
        }

        static void AddEmployee(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Isci elave etmek istediyiniz department adini daxil edin");
            string name = Console.ReadLine();
            Department dep = null;
            foreach (var D in humanResourceManager.departments)
            {
                if (D == null)
                    break;
                else if (D.Name == name)
                {
                    dep = D;
                    break;
                }
            }
            if (dep == null)
            {
                Console.WriteLine("Duzgun daxil etmediniz");
                return;
            }

            Console.WriteLine("Iscinin ad ve soyadini daxil edin");
            string FullName = Console.ReadLine();
            Console.WriteLine("Iscinin vezifesini daxil edin");
            string Position = Console.ReadLine();
            Console.WriteLine("Iscinin maasini elave edin(minumum 250)");
            string salaryLimit = Console.ReadLine();
            double salaryLimitNum = 0;
            while (!double.TryParse(salaryLimit, out salaryLimitNum) || salaryLimitNum <= 250 || salaryLimitNum > dep.SalaryLimit)
            {
                Console.WriteLine("Iscinin maasini duzgun daxil edin(minumum 250)");
                salaryLimit = Console.ReadLine();

            }
            dep.AddEmployee(new Employee(FullName, Position, salaryLimitNum, dep.Name));

        }
        static void UpdateEmployee(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Isci nomresini daxil edin");
            string number = Console.ReadLine();
            int trueNumber = 0;
            while (!int.TryParse(number, out trueNumber) || trueNumber <= 0)
            {
                Console.WriteLine("Iscinin nomresini duzgun daxil edin(minumum 1 den baslayir)");
                number = Console.ReadLine();

            }
            Employee emp = null;
            Department dep = null;
            foreach (var D in humanResourceManager.departments)
            {
                if (D == null)
                    break;
               
                foreach (var E in D.Employees)
                {
                    if (E == null)
                        break;
                    else if (E.No.Substring(2) == (trueNumber + 1000).ToString())
                    {
                        emp = E;
                        dep = D;
                        break;

                    }
                }

              
            }
            if(emp == null)
            {
                Console.WriteLine("Bele bir isci yoxdur");
                return;
            }
            Console.WriteLine("Iscinin adi " + emp.FullName);
            Console.WriteLine("Iscinin indiki maasi " + emp.Salary);
            Console.WriteLine("Iscinin indiki vezifesi " + emp.Position);

            Console.WriteLine("Iscinin vezifesini daxil edin");
            string Position = Console.ReadLine();
            Console.WriteLine("Iscinin maasini elave edin: minumum 250, maximum " + (dep.SalaryLimit - 1));
            string salaryLimit = Console.ReadLine();
            double salaryLimitNum = 0;
            while (!double.TryParse(salaryLimit, out salaryLimitNum) || salaryLimitNum <= 250 || salaryLimitNum > dep.SalaryLimit)
            {
                Console.WriteLine("Iscinin maasini duzgun daxil edin: minumum 250, maximum " + (dep.SalaryLimit - 1));
                salaryLimit = Console.ReadLine();

            }
            emp.Salary = salaryLimitNum;
            emp.Position = Position;
            Console.WriteLine("Isci ugurla yenilendi ");

        }


        //static void AddDepartment(ref HumanResourceManager humanResourceManager)
        //{
        //    Console.WriteLine("Departmentin adini daxil edin:");
        //    string name = Console.ReadLine();
        //    int nameNum = 0;
        //    do
        //    {
        //        Console.WriteLine("duzgun daxil edin");
        //    } while (int.TryParse(name, out nameNum));
        //    Console.WriteLine("Yeniden daxil edin");
        //    Console.Clear();
        //    name = Console.ReadLine();



        //}







        //static void GetDepartment(ref HumanResourceManager humanResourceManager)
        //{
        //    if (humanResourceManager.departments.Length > 0)
        //    {
        //        foreach (var item in humanResourceManager.departments)
        //        {
        //            Console.WriteLine($"{item} - ortalama maas: {item.CalcSalaryAverage(item)}");
        //        }
        //    }
        //    else
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Department yoxdur");
        //    }

        //}
        //static void EditDepartment(ref HumanResourceManager humanResourceManager)
        //{
        //    GetDepartment(ref humanResourceManager);
        //    if (humanResourceManager.departments.Length > 0)
        //    {
        //        bool check = true;
        //        string name;
        //        do
        //        {
        //            if (check)
        //            {
        //                Console.WriteLine("Deyiseceyiniz departmentin adini daxil edin");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Duzgun daxil edin");
        //            }
        //            name = Console.ReadLine();
        //            check = false;

        //        } while (humanResourceManager.CheckName(name));
        //        do
        //        {
        //            if (check)
        //            {
        //                Console.WriteLine("Duzgun Department daxil edin");
        //                name = Console.ReadLine();

        //            }
        //            check = true;
        //        } while (humanResourceManager.FindoutDepartment(name));
        //    }
        //}


    }


}

