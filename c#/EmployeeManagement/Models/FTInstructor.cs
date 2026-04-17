namespace EmployeeManagement.Models
{
    // Full-time instructor employee with an office assignment.
    public class FTInstructor : FTEmployee
    {
        public string OfficeId { get; }

        public FTInstructor(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department, double salary, string officeId)
            : base(id, firstName, lastName, dateOfBirth, position, department, salary)
        {
            OfficeId = !string.IsNullOrWhiteSpace(officeId)
                ? officeId
                : throw new System.ArgumentException("Office id cannot be null or empty.", nameof(officeId));
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"FT Instructor {FirstName} {LastName} reports to the manager from office {OfficeId}.");
        }

        public override string ToString()
        {
            return base.ToString() + $", OfficeId={OfficeId}";
        }
    }
}
