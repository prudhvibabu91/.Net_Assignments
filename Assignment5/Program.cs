    using System;
    using System.Collections.Generic;
    using Assignment5;

namespace Assignment5
{
    public abstract class Employee
    {
        private int id;
        private string name;
        private string reportingManager;
        public static int TotalEmployees = 0;

        public Employee(int id, string name, string manager)
        {
            this.id = id;
            this.name = name;
            this.reportingManager = manager;
            TotalEmployees++;
        }

        protected int ID => id;
        protected string Name => name;
        protected string ReportingManager => reportingManager;

        public abstract void DisplayDetails();
    }

    public class OnContract : Employee
    {
        private DateTime contractDate;
        private int durationInMonths;
        private double charges;

        public OnContract(int id, string name, string manager, DateTime contractDate, int duration, double charges)
            : base(id, name, manager)
        {
            this.contractDate = contractDate;
            this.durationInMonths = duration;
            this.charges = charges;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("------ OnContract Employee ------");
            Console.WriteLine($"ID: {ID}, Name: {Name}, Manager: {ReportingManager}");
            Console.WriteLine($"Contract Date: {contractDate.ToShortDateString()}, Duration: {durationInMonths} months, Charges: Rs. {charges:N0}");
        }
    }

    public class OnPayroll : Employee
    {
        private DateTime joiningDate;
        private int experienceInYears;
        private double basicSalary;
        private double da;
        private double hra;
        private double pf;
        private double netSalary;

        public OnPayroll(int id, string name, string manager, DateTime joiningDate, int exp, double basic)
            : base(id, name, manager)
        {
            this.joiningDate = joiningDate;
            this.experienceInYears = exp;
            this.basicSalary = basic;
            CalculateSalary();
        }

        private void CalculateSalary()
        {
            if (experienceInYears > 10)
            {
                da = 0.10 * basicSalary;
                hra = 0.085 * basicSalary;
                pf = 6200;
            }
            else if (experienceInYears > 7)
            {
                da = 0.07 * basicSalary;
                hra = 0.065 * basicSalary;
                pf = 4100;
            }
            else if (experienceInYears > 5)
            {
                da = 0.041 * basicSalary;
                hra = 0.038 * basicSalary;
                pf = 1800;
            }
            else
            {
                da = 0.019 * basicSalary;
                hra = 0.02 * basicSalary;
                pf = 1200;
            }

            netSalary = basicSalary + da + hra - pf;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("------ OnPayroll Employee ------");
            Console.WriteLine($"ID: {ID}, Name: {Name}, Manager: {ReportingManager}");
            Console.WriteLine($"Joining Date: {joiningDate.ToShortDateString()}, Experience: {experienceInYears} years");
            Console.WriteLine($"Basic Salary: Rs. {basicSalary:N0}, DA: Rs. {da:N0}, HRA: Rs. {hra:N0}, PF: Rs. {pf:N0}, Net Salary: Rs. {netSalary:N0}");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Employee> employees = new List<Employee>();

            employees.Add(new OnContract(1, "Kavi", "Mr. John", DateTime.Parse("2024-01-15"), 12, 750000));
            employees.Add(new OnPayroll(2, "Edgar", "Ms. Jane", DateTime.Parse("2015-06-20"), 11, 70000));
            employees.Add(new OnPayroll(3, "mukesh", "Mr. John", DateTime.Parse("2018-08-12"), 6, 50000));

            foreach (Employee emp in employees)
            {
                emp.DisplayDetails();
                Console.WriteLine();
            }

            Console.WriteLine($"Total Employees: {Employee.TotalEmployees}");
        }
    }
}

