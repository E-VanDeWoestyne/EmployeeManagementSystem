using System;
using EmployeeManagement.Exceptions;
using InvalidDataException = EmployeeManagement.Exceptions.InvalidDataException;

namespace EmployeeManagement.Models
{
    // Base class for part-time employees who are paid by hour.
    public class PTEmployee : Employee
    {
        public double Rate { get; }
        public int Hours { get; }

        public PTEmployee(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department, double rate, int hours)
            : base(id, firstName, lastName, dateOfBirth, position, department)
        {
            if (rate < 0)
            {
                throw new InvalidDataException("Rate cannot be negative.");
            }

            if (hours < 0)
            {
                throw new InvalidDataException("Hours cannot be negative.");
            }

            Rate = rate;
            Hours = hours;
        }

        // Calculates and prints pay for part-time work.
        public override void GetPaid()
        {
            var payment = Rate * Hours;
            Console.WriteLine($"{Position} {FirstName} {LastName} receives a part-time payment of {payment:C} for {Hours} hours at {Rate:C} per hour.");
        }

        // Includes bonus payment for part-time employees.
        public override void GetPaid(double bonus)
        {
            if (bonus < 0)
            {
                throw new PayrollMathException("Bonus cannot be negative.");
            }

            var payment = Rate * Hours + bonus;
            Console.WriteLine($"{Position} {FirstName} {LastName} receives a part-time payment of {payment:C} including bonus {bonus:C}.");
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"{Position} {FirstName} {LastName} reports to the manager with a part-time employee schedule.");
        }

        public override string ToString()
        {
            return base.ToString() + $", Rate={Rate:C}, Hours={Hours}";
        }
    }
}
