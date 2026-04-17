using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    // Responsible for reading and writing employee data from the file system.
    public class FileManager
    {
        private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };

        public string FilePath { get; }
        public List<Employee> Employees { get; }

        public FileManager(string filePath)
        {
            FilePath = !string.IsNullOrWhiteSpace(filePath)
                ? filePath
                : throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            Employees = new List<Employee>();
        }

        // Runs the load and save operations in sequence.
        public void Run()
        {
            ReadFile();
            WriteFile();
        }

        // Serializes employee data to JSON and writes it to the configured file.
        public void WriteFile()
        {
            var json = JsonSerializer.Serialize(Employees, JsonOptions);
            File.WriteAllText(FilePath, json);
            Console.WriteLine($"Wrote {Employees.Count} employee record(s) to {FilePath}.");
        }

        // Reads and deserializes employee data from the configured file.
        public void ReadFile()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine($"File not found: {FilePath}. A new file will be created when writing.");
                return;
            }

            var json = File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine($"File {FilePath} is empty.");
                return;
            }

            try
            {
                var loadedEmployees = JsonSerializer.Deserialize<List<Employee>>(json, JsonOptions);
                if (loadedEmployees is null)
                {
                    Console.WriteLine($"No employee records found in {FilePath}.");
                    return;
                }

                Employees.Clear();
                Employees.AddRange(loadedEmployees);
                Console.WriteLine($"Loaded {loadedEmployees.Count} employee record(s) from {FilePath}.");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to parse employee data from {FilePath}: {ex.Message}");
            }
        }
    }
}
