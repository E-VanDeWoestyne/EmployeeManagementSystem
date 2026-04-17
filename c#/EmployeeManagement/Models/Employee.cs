using System;
using System.Text.Json.Serialization;
using EmployeeManagement.Exceptions;
using InvalidDataException = EmployeeManagement.Exceptions.InvalidDataException;

namespace EmployeeManagement.Models
{
    // Base class for all employee types with polymorphic JSON support.
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(FTEmployee), "FTEmployee")]
    [JsonDerivedType(typeof(FTAdmin), "FTAdmin")]
    [JsonDerivedType(typeof(FTInfoTech), "FTInfoTech")]
    [JsonDerivedType(typeof(FTInstructor), "FTInstructor")]
    [JsonDerivedType(typeof(FTPayroll), "FTPayroll")]
    [JsonDerivedType(typeof(PTEmployee), "PTEmployee")]
    [JsonDerivedType(typeof(PTInfoTech), "PTInfoTech")]
    [JsonDerivedType(typeof(PTInstructor), "PTInstructor")]
    public abstract class Employee
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateOnly DateOfBirth { get; }
        public string Position { get; }
        public Departments Department { get; }

        protected Employee(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Employee id must be greater than zero.");
            }

            FirstName = !string.IsNullOrWhiteSpace(firstName)
                ? firstName
                : throw new InvalidDataException("First name cannot be null or empty.");

            LastName = !string.IsNullOrWhiteSpace(lastName)
                ? lastName
                : throw new InvalidDataException("Last name cannot be null or empty.");

            if (dateOfBirth > DateOnly.FromDateTime(DateTime.Today))
            {
                throw new InvalidDataException("Date of birth cannot be in the future.");
            }

            if (string.IsNullOrWhiteSpace(position))
            {
                throw new InvalidDataException("Position cannot be null or empty.");
            }

            Id = id;
            DateOfBirth = dateOfBirth;
            Position = position;
            Department = department;
        }

        // Abstract method that must be implemented by each concrete employee type.
        public abstract void GetPaid();

        // Overloaded method demonstrating static binding with bonus payment.
        public virtual void GetPaid(double bonus)
        {
            if (bonus < 0)
            {
                throw new PayrollMathException("Bonus cannot be negative.");
            }

            Console.WriteLine($"{Position} {FirstName} {LastName} receives a bonus of {bonus:C}.");
        }

        // Virtual method that can be overridden by derived classes for dynamic binding.
        public virtual void ReportToManager()
        {
            Console.WriteLine($"{Position} {FirstName} {LastName} reports to their manager.");
        }

        // Provides a readable string representation for debugging and logging.
        public override string ToString()
        {
            return $"[{GetType().Name}] Id={Id}, Name={FirstName} {LastName}, DOB={DateOfBirth:yyyy-MM-dd}, Position={Position}, Department={Department}";
        }
    }
}
