using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using EmployeeManagement.Exceptions;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using InvalidDataException = EmployeeManagement.Exceptions.InvalidDataException;

namespace EmployeeManagement
{
    internal static class Program
    {
        // Entry point for the EmployeeManagement prototype application.
        // This method demonstrates object creation, polymorphism, exception handling,
        // manager reporting, file persistence, and simple thread-based parallelism.
        private static void Main()
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "employees.txt");
            var fileManager = new FileManager(filePath);
            var employees = new List<Employee>();

            try
            {
                // Create a set of sample employees for the prototype.
                employees.Add(new FTInstructor(
                    id: 1,
                    firstName: "Janet",
                    lastName: "Morris",
                    dateOfBirth: new DateOnly(1982, 11, 4),
                    position: "Instructor",
                    department: Departments.Staff,
                    salary: 92000,
                    officeId: "B12"));

                employees.Add(new FTPayroll(
                    id: 2,
                    firstName: "Rafael",
                    lastName: "Martinez",
                    dateOfBirth: new DateOnly(1979, 6, 19),
                    position: "Payroll Specialist",
                    department: Departments.Payroll,
                    salary: 78000,
                    certificateId: "PAY-4432"));

                employees.Add(new PTInstructor(
                    id: 3,
                    firstName: "Ava",
                    lastName: "Chen",
                    dateOfBirth: new DateOnly(1996, 2, 17),
                    position: "Adjunct Instructor",
                    department: Departments.Staff,
                    rate: 42.50,
                    hours: 18,
                    maxHours: 20));

                employees.Add(new PTInfoTech(
                    id: 4,
                    firstName: "Daniel",
                    lastName: "Owens",
                    dateOfBirth: new DateOnly(1992, 9, 5),
                    position: "IT Support",
                    department: Departments.IT,
                    rate: 36.00,
                    hours: 22,
                    mentorName: "Priya"));
            }
            catch (InvalidDataException ex)
            {
                // Handle invalid employee data provided during object creation.
                Console.WriteLine($"Invalid employee data: {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                // Catch any other unexpected errors and stop the program.
                Console.WriteLine($"Unexpected error while creating employees: {ex.Message}");
                return;
            }

            // Demonstrate dynamic binding: each employee invokes their own implementation.
            foreach (var employee in employees)
            {
                employee.ReportToManager();
                employee.GetPaid();
            }

            try
            {
                // Demonstrate overloaded method call for static binding with bonuses.
                employees[0].GetPaid(500);
                employees[2].GetPaid(150);

                // This call will throw a PayrollMathException because the bonus is negative.
                employees[3].GetPaid(-25);
            }
            catch (PayrollMathException ex)
            {
                Console.WriteLine($"Payroll error: {ex.Message}");
            }

            // Add demo employees to the file manager for persistence.
            fileManager.Employees.AddRange(employees);

            var manager = new Manager();
            manager.AddSubordinate(employees[0]);
            manager.AddSubordinate(employees[2]);
            manager.AddSubordinate(employees[3]);

            manager.ReportToManager();

            // Run file I/O in a separate thread to demonstrate parallel execution.
            var fileThread = new Thread(fileManager.Run)
            {
                IsBackground = true,
                Name = "FileManagerThread"
            };

            fileThread.Start();

            Console.WriteLine("\nMain thread continues while file operations execute in a separate thread.");
            DisplayEmployeeSummary(employees);

            // Wait for the file manager thread to complete before exiting.
            fileThread.Join();
            Console.WriteLine("File operations completed.");
        }

        private static void DisplayEmployeeSummary(IEnumerable<Employee> employees)
        {
            Console.WriteLine("\nEmployee summary:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }

            Console.WriteLine();
        }
    }
}

