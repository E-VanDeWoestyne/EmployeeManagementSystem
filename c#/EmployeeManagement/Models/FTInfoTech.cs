namespace EmployeeManagement.Models
{
    public class FTInfoTech : FTEmployee
    {
        public string OnCallGroup { get; }

        public FTInfoTech(int id, string firstName, string lastName, DateOnly dateOfBirth, string position, Departments department, double salary, string onCallGroup)
            : base(id, firstName, lastName, dateOfBirth, position, department, salary)
        {
            OnCallGroup = !string.IsNullOrWhiteSpace(onCallGroup)
                ? onCallGroup
                : throw new System.ArgumentException("On-call group cannot be null or empty.", nameof(onCallGroup));
        }

        public override void ReportToManager()
        {
            Console.WriteLine($"FT InfoTech {FirstName} {LastName} reports to the manager and is assigned to group {OnCallGroup}.");
        }

        public override string ToString()
        {
            return base.ToString() + $", OnCallGroup={OnCallGroup}";
        }
    }
}
