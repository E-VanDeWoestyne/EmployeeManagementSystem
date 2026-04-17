using System;

namespace EmployeeManagement.Models
{
    public class FTAdmin : FTEmployee
    {
        public string AccessCode { get; }

        public FTAdmin(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department, double salary, string accessCode)
            : base(id, firstName, lastName, dateOfBirth, position, department, salary)
        {
            AccessCode = !string.IsNullOrWhiteSpace(accessCode)
                ? accessCode
                : throw new ArgumentException("Access code cannot be null or empty.", nameof(accessCode));
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"FT Admin {FirstName} {LastName} reports to the manager and uses access code {AccessCode}.");
        }

        public override string ToString()
        {
            return base.ToString() + $", AccessCode={AccessCode}";
        }
    }
}
