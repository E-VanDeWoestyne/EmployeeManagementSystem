using System;
using EmployeeManagement.Exceptions;
using InvalidDataException = EmployeeManagement.Exceptions.InvalidDataException;

namespace EmployeeManagement.Models
{
    public class FTEmployee : Employee
    {
        public double Salary { get; }

        public FTEmployee(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department, double salary)
            : base(id, firstName, lastName, dateOfBirth, position, department)
        {
            if (salary < 0)
            {
                throw new InvalidDataException("Salary cannot be negative.");
            }

            Salary = salary;
        }

        public override void GetPaid()
        {
            Console.WriteLine($"{Position} {FirstName} {LastName} receives salary payment of {Salary:C}.");
        }

        public override void GetPaid(double bonus)
        {
            if (bonus < 0)
            {
                throw new PayrollMathException("Bonus cannot be negative.");
            }

            Console.WriteLine($"{Position} {FirstName} {LastName} receives salary payment of {Salary:C} plus bonus {bonus:C}.");
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"{Position} {FirstName} {LastName} reports to the manager with a full-time employee workload.");
        }

        public override string ToString()
        {
            return base.ToString() + $", Salary={Salary:C}";
        }
    }
}
