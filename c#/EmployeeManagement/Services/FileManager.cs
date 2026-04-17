using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class FileManager
    {
        public string FilePath { get; }
        public List<Employee> Employees { get; }

        public FileManager(string filePath)
        {
            FilePath = !string.IsNullOrWhiteSpace(filePath)
                ? filePath
                : throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            Employees = new List<Employee>();
        }

        public void Run()
        {
            ReadFile();
            WriteFile();
        }

        public void WriteFile()
        {
            var lines = Employees.Select(employee => employee.ToString());
            File.WriteAllLines(FilePath, lines);
            Console.WriteLine($"Wrote {Employees.Count} employee record(s) to {FilePath}.");
        }

        public void ReadFile()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine($"File not found: {FilePath}. A new file will be created when writing.");
                return;
            }

            var lines = File.ReadAllLines(FilePath);
            Console.WriteLine($"Read {lines.Length} line(s) from {FilePath}.");
        }
    }
}
