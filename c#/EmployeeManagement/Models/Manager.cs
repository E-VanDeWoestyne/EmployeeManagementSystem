using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    // Simple manager class that tracks a list of subordinate employees.
    public class Manager
    {
        public List<Employee> Subordinates { get; }

        public Manager()
        {
            Subordinates = new List<Employee>();
        }

        public void AddSubordinate(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            Subordinates.Add(employee);
        }

        // Prints a summary of employees managed by this manager.
        public void ReportToManager()
        {
            Console.WriteLine($"Manager has {Subordinates.Count} subordinate(s) reporting to them.");
            foreach (var subordinate in Subordinates)
            {
                Console.WriteLine($" - {subordinate.Position} {subordinate.FirstName} {subordinate.LastName}");
            }
        }
    }
}
