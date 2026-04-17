namespace EmployeeManagement.Models
{
    // Full-time payroll employee with a certification identifier.
    public class FTPayroll : FTEmployee
    {
        public string CertificateId { get; }

        public FTPayroll(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department, double salary, string certificateId)
            : base(id, firstName, lastName, dateOfBirth, position, department, salary)
        {
            CertificateId = !string.IsNullOrWhiteSpace(certificateId)
                ? certificateId
                : throw new System.ArgumentException("Certificate id cannot be null or empty.", nameof(certificateId));
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"FT Payroll {FirstName} {LastName} reports to the manager with certificate {CertificateId}.");
        }

        public override string ToString()
        {
            return base.ToString() + $", CertificateId={CertificateId}";
        }
    }
}
